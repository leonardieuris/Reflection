
namespace ConsoleAppReflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RenameAttribute : Attribute
    {
        public string AttributeName;

        public RenameAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }
    }
}
