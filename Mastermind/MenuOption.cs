namespace Mastermind
{
    class MenuOption
    {
        private string Key { get; }
        private string Description { get; }

        public MenuOption(string key, string description)
        {
            Key = key;
            Description = description;
        }

        public bool Matches(string input) =>
            !ReferenceEquals(null, input) && Key == input;

        public override string ToString() =>
            $"[{Key}] : {Description}";
    }
}
