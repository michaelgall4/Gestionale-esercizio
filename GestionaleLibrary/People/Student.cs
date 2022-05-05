namespace GestionaleLibrary.People
{
    public class Student : Person
    {
        public int IdStudente { get; set; }
        //public int IdPerson { get; set; }
        public string Matricola { get; set; }
        public DateTime DataIscrizione { get; set; }
    }
}
