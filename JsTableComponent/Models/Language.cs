namespace JsTableComponent.Models
{
    public class Language
    {
        public string Name { get; set; }
        public LanguageLevel LanguageLevel { get; set; }

    }

    public enum LanguageLevel
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }
}
