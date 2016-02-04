namespace Entitas {
    public partial class Entity {
        public ColorComponent color { get { return (ColorComponent)GetComponent(ComponentIds.Color); } }

        public bool hasColor { get { return HasComponent(ComponentIds.Color); } }

        public Entity AddColor(UnityEngine.Color newColor) {
            var componentPool = GetComponentPool(ComponentIds.Color);
            var component = (ColorComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ColorComponent());
            component.color = newColor;
            return AddComponent(ComponentIds.Color, component);
        }

        public Entity ReplaceColor(UnityEngine.Color newColor) {
            var componentPool = GetComponentPool(ComponentIds.Color);
            var component = (ColorComponent)(componentPool.Count > 0 ? componentPool.Pop() : new ColorComponent());
            component.color = newColor;
            ReplaceComponent(ComponentIds.Color, component);
            return this;
        }

        public Entity RemoveColor() {
            return RemoveComponent(ComponentIds.Color);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherColor;

        public static IMatcher Color {
            get {
                if (_matcherColor == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Color);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherColor = matcher;
                }

                return _matcherColor;
            }
        }
    }
}