using GestionaleLibrary.People;
using System.Data.SqlClient;
using GestionaleLibrary;
using GestionaleLibrary.Persister;
using Gestionale;
using Gestionale.Handler;

//var personHandler = new PersonHandler();
//personHandler.AddPersona();

//var subjectHandler = new SubjectHandler();
//subjectHandler.AddMateria();

//var studentHandler = new StudentHandler();
//studentHandler.AddStudente();

//var personHandler = new PersonHandler();
//personHandler.DeletePersona(15);

var teacherHandler = new TeacherHandler();
teacherHandler.AddDocente();

Console.ReadLine();