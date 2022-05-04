using GestionaleLibrary.People;
using System.Data.SqlClient;
using GestionaleLibrary;
using GestionaleLibrary.Persister;
using Gestionale;
using Gestionale.Handler;

var personHandler = new PersonHandler();
personHandler.AddPersona();

var subjectHandler = new SubjectHandler();
subjectHandler.AddMateria();

Console.ReadLine();