namespace Domain
{
    public class Email
    {
        public Email(string adress)
        {
            Adress = adress;
        }

        public string Adress { get; private set; }
    }
}