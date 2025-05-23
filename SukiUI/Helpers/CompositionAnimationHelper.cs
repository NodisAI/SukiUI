using Avalonia.Animation.Easings;
using Avalonia.Rendering.Composition;

namespace SukiUI.Helpers
{
    public static class CompositionAnimationHelper
    {
        public static void MakeScrollAnimated(this CompositionVisual? compositionVisual, double millis = 100)
        {
            if (compositionVisual == null) return;

            var compositor = compositionVisual.Compositor;
            var animationGroup = compositor.CreateAnimationGroup();

            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.Target = "Offset";

            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            offsetAnimation.Duration = TimeSpan.FromMilliseconds(millis);

            var implicitAnimationCollection = compositor.CreateImplicitAnimationCollection();
            animationGroup.Add(offsetAnimation);
            implicitAnimationCollection["Offset"] = animationGroup;
            compositionVisual.ImplicitAnimations = implicitAnimationCollection;
        }

        public static void MakeOpacityAnimated(this CompositionVisual? compositionVisual, double millis = 200, Easing? easing = null)
        {
            if (compositionVisual == null) return;

            var compositor = compositionVisual.Compositor;
            var animationGroup = compositor.CreateAnimationGroup();

            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Target = "Opacity";
            opacityAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue", easing);
            opacityAnimation.Duration = TimeSpan.FromMilliseconds(millis);

            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.Target = "Offset";
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue", easing);
            offsetAnimation.Duration = TimeSpan.FromMilliseconds(millis);
            animationGroup.Add(offsetAnimation);
            animationGroup.Add(opacityAnimation);

            var implicitAnimationCollection = compositor.CreateImplicitAnimationCollection();
            implicitAnimationCollection["Opacity"] = animationGroup;
            implicitAnimationCollection["Offset"] = animationGroup;
            compositionVisual.ImplicitAnimations = implicitAnimationCollection;
        }

        public static void MakeSizeAnimated(this CompositionVisual? compositionVisual, double millis = 200, Easing? easing = null)
        {
            if (compositionVisual == null) return;

            var compositor = compositionVisual.Compositor;
            var animationGroup = compositor.CreateAnimationGroup();

            var sizeAnimation = compositor.CreateVector2KeyFrameAnimation();
            sizeAnimation.Target = "Size";
            sizeAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue", easing);
            sizeAnimation.Duration = TimeSpan.FromMilliseconds(millis);

            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.Target = "Offset";
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue", easing);
            offsetAnimation.Duration = TimeSpan.FromMilliseconds(millis);

            animationGroup.Add(sizeAnimation);
            animationGroup.Add(offsetAnimation);

            var implicitAnimationCollection = compositor.CreateImplicitAnimationCollection();
            implicitAnimationCollection["Size"] = animationGroup;
            implicitAnimationCollection["Offset"] = animationGroup;

            compositionVisual.ImplicitAnimations = implicitAnimationCollection;
        }

        public static void MakeSizeOpacityAnimated(this CompositionVisual? compositionVisual, double millis = 200)
        {
            if (compositionVisual == null) return;

            var compositor = compositionVisual.Compositor;
            var animationGroup = compositor.CreateAnimationGroup();

            var sizeAnimation = compositor.CreateVector2KeyFrameAnimation();
            sizeAnimation.Target = "Size";
            sizeAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            sizeAnimation.Duration = TimeSpan.FromMilliseconds(millis);

            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.Target = "Offset";
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            offsetAnimation.Duration = TimeSpan.FromMilliseconds(millis);

            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Target = "Opacity";
            opacityAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            opacityAnimation.Duration = TimeSpan.FromMilliseconds(millis);
            animationGroup.Add(sizeAnimation);
            animationGroup.Add(opacityAnimation);
            animationGroup.Add(offsetAnimation);

            var implicitAnimationCollection = compositor.CreateImplicitAnimationCollection();
            implicitAnimationCollection["Size"] = animationGroup;
            implicitAnimationCollection["Opacity"] = animationGroup;
            implicitAnimationCollection["Offset"] = animationGroup;

            compositionVisual.ImplicitAnimations = implicitAnimationCollection;
        }
    }
}