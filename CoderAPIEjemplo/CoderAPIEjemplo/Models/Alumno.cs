namespace CoderAPIEjemplo.Models
{
    public class Alumno
    {
        #region Staments
        private int _id;
        private string _name;
        private string _surname;
        private string _email;
        #endregion


        #region Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        #endregion


        #region Builders
        public Alumno()
        {

        }

        public Alumno(int id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
        #endregion


        #region Methods
        public List<Alumno> TraerAlumnos()
        {
            return new List<Alumno>();
        }
        #endregion
    }

}
