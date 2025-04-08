
namespace Common.Enums
{

    public enum ProductType
    {
        Simple,
        Variable,
        Digital,
        Subscription
    }

    public enum AttributeType
    {
        Text,
        Number,
        Boolean,
        DateTime,
        Dropdown
    }

    public enum RelationType
    {
        Related,
        CrossSell,
        UpSell
    }

    public enum SubscriptionTier
    {
        Basic,
        Professional,
        Enterprise
    }

    public enum WeightUnit { Kg, Lb, Oz, G }
    public enum DimensionUnit { Cm, In, M, Mm }
}
