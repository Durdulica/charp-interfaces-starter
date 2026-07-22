namespace Interfaces.ex5.Models
{
    public class Cuvant : IComparabil<Cuvant>
    {
        public string Text {  get; }

        public Cuvant(string text) { Text = text; }

        public int ComparaCu(Cuvant altul)
        {
            return string.Compare(Text, altul.Text);
        }
    }
}