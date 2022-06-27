using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab1
{
    class Program
    {
        static List<PersonalInfo> personalData = new List<PersonalInfo>()
        {
            new PersonalInfo("Shynkarenko","Yevhen","Anatoliyovych",   DateTime.Parse("1985-12-30"), "bachelor", 1),
            new PersonalInfo("Brovarenko", "Adam", "Ivanovych",        DateTime.Parse("1963-03-28"), "bachelor", 2),
            new PersonalInfo("Kravchenko", "Lyubov", "Valentynivna",   DateTime.Parse("1981-12-06"), "Ph.D",     3),
            new PersonalInfo("Mel'nychenko", "Olena", "Andriyovych",   DateTime.Parse("1985-10-14"), "master",   4),
            new PersonalInfo("Pavlyuk", "Tamara", "Serhiyivna",        DateTime.Parse("2000-01-25"), "bachelor", 5),
            new PersonalInfo("Dmytrenko", "Danylo", "Mykolayovych",    DateTime.Parse("1963-05-02"), "master",   6),
            new PersonalInfo("Ponomarenko", "Andriy", "Yosypovych",    DateTime.Parse("1991-01-20"), "master",   7),
            new PersonalInfo("Shevchenko", "Vsevolod", "Oleksiyovych", DateTime.Parse("1987-05-27"), "bachelor", 8),
            new PersonalInfo("Ponomarchuk", "Valentyna", "Romanivna",  DateTime.Parse("1969-08-17"), "Ph.D",     9)
        };
        static List<WorkerInfo> workerData = new List<WorkerInfo>() 
        {
            new WorkerInfo(1, "6011780282043117", "narrow", DateTime.Parse("2020-08-11")),
            new WorkerInfo(2, "4916686643712357", "broad",  DateTime.Parse("2020-02-26")),
            new WorkerInfo(3, "5379940837068906", "broad",  DateTime.Parse("2021-04-12")),
            new WorkerInfo(4, "5128346448421811", "narrow", DateTime.Parse("2020-10-30")),
            new WorkerInfo(5, "5476029642508538", "broad",  DateTime.Parse("2021-10-19")),
            new WorkerInfo(6, "4856489104225234", "broad",  DateTime.Parse("2021-03-22")),
            new WorkerInfo(7, "3479960571264937", "narrow", DateTime.Parse("2021-08-21")),
            new WorkerInfo(8, "4916826615417733", "narrow", DateTime.Parse("2020-07-05")),
            new WorkerInfo(9, "6011937586586205", "broad",  DateTime.Parse("2021-11-03"))
        };
        static List<MonthlySalary> salaries = new List<MonthlySalary>()
        {
            new MonthlySalary("6011780282043117", DateTime.Parse("2021-09-01"), 16000),
            new MonthlySalary("6011780282043117", DateTime.Parse("2021-10-01"), 15500),
            new MonthlySalary("6011780282043117", DateTime.Parse("2021-11-01"), 15300),

            new MonthlySalary("4916686643712357", DateTime.Parse("2021-09-01"), 18000),
            new MonthlySalary("4916686643712357", DateTime.Parse("2021-10-01"), 18000),
            new MonthlySalary("4916686643712357", DateTime.Parse("2021-11-01"), 17800),

            new MonthlySalary("5379940837068906", DateTime.Parse("2021-09-01"), 18500),
            new MonthlySalary("5379940837068906", DateTime.Parse("2021-10-01"), 18500),
            new MonthlySalary("5379940837068906", DateTime.Parse("2021-11-01"), 18500),

            new MonthlySalary("5128346448421811", DateTime.Parse("2021-09-01"), 16200),
            new MonthlySalary("5128346448421811", DateTime.Parse("2021-10-01"), 16000),
            new MonthlySalary("5128346448421811", DateTime.Parse("2021-11-01"), 16000),

            new MonthlySalary("5476029642508538", DateTime.Parse("2021-11-01"), 17500),

            new MonthlySalary("4856489104225234", DateTime.Parse("2021-09-01"), 17800),
            new MonthlySalary("4856489104225234", DateTime.Parse("2021-10-01"), 17800),
            new MonthlySalary("4856489104225234", DateTime.Parse("2021-11-01"), 17800),

            new MonthlySalary("3479960571264937", DateTime.Parse("2021-10-01"), 16000),
            new MonthlySalary("3479960571264937", DateTime.Parse("2021-11-01"), 16000),

            new MonthlySalary("4916826615417733", DateTime.Parse("2021-09-01"), 16500),
            new MonthlySalary("4916826615417733", DateTime.Parse("2021-10-01"), 16500),
            new MonthlySalary("4916826615417733", DateTime.Parse("2021-11-01"), 16200),
        };
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\nЗапит №1. Проста вибірка - виведення всіх особистих даних працівників\n");

            var q1 = from person in personalData                                                        
                     select person;
            foreach (var person in q1)
                Console.WriteLine(person);

            Console.WriteLine("\nЗапит №2. Вибірка певних полів створенням анонімного типу\n");

            var q2 = from data in personalData
                     select new { ID = data.personalID, name = data.name, education = data.education };
            foreach (var selectedData in q2)
                Console.WriteLine($"{selectedData.ID}. {selectedData.name} - {selectedData.education}");

            Console.WriteLine("\nЗапит №3. Вибірка елементів за умовою\n");

            var q3 = from workers in workerData
                     where workers.hiredDate < DateTime.Parse("2021-01-01")
                     select workers;
            foreach (var worker in q3)
                Console.WriteLine(worker);

            Console.WriteLine("\nЗапит №4. Вибірка з сортуванням\n");

            var q4 = from payments in salaries
                     orderby payments.monthYear ascending
                     select payments;
            foreach (var payment in q4)
                Console.WriteLine(payment);

            Console.WriteLine("\nЗапит №5. Вибірка за умовою з сортуванням методами розширення\n");

            var q5 = salaries.Where(payment => payment.monthYear == DateTime.Parse("11-2021")).OrderBy(payment => payment.salary);
            foreach (var payment in q5)
                Console.WriteLine(payment);

            Console.WriteLine("\nЗапит №6. Вибірка з використанням join\n");

            var q6 = from people in personalData
                     join worker in workerData
                     on people.personalID equals worker.personalID
                     select new { personalID = people.personalID, surname = people.surname, name = people.name, middle = people.middle, taxpayerCardID = worker.taxpayerCardID };
            foreach (var fullInfo in q6)
                Console.WriteLine($"{fullInfo.personalID}. {fullInfo.surname} {fullInfo.name} {fullInfo.middle} - {fullInfo.taxpayerCardID}");

            Console.WriteLine("\nЗапит №7. Вибірка з використанням join та збереженням об'єктів\n");

            var q7 = from people in personalData
                     join worker in workerData
                     on people.personalID equals worker.personalID
                     orderby people.personalID ascending
                     select new { group1 = people, group2 = worker};
            foreach (var groupInfo in q7)
                Console.WriteLine($"{groupInfo.group1.personalID}. {groupInfo.group1.surname}\thired {groupInfo.group2.hiredDate.ToString("dd/MM/yyyy")} - education: {groupInfo.group1.education},\tspecialization: {groupInfo.group2.specialization}");

            Console.WriteLine("\nЗапит №8. Вибірка об'єднання трьох таблиць з використанням Left Join\n");

            var q8 = from people in personalData
                     join worker in workerData
                     on people.personalID equals worker.personalID into table1
                     from info1 in table1
                     join payments in salaries
                     on info1.taxpayerCardID equals payments.taxpayerCardID into table2
                     from info2 in table2.DefaultIfEmpty(new MonthlySalary("null", DateTime.MinValue, 0))
                     select new { group1 = people, group2 = info1 , group3 = info2};
            foreach (var fullestInfo in q8)
                Console.WriteLine($"{fullestInfo.group1.personalID}. {fullestInfo.group1.surname} {fullestInfo.group1.name} {fullestInfo.group1.middle}\t- {fullestInfo.group3.monthYear.ToString("dd/MM/yyyy")}: {fullestInfo.group3.salary} UAH");

            Console.WriteLine("\nЗапит №9. Вибірка з Inner join методами розширення\n");

            var q9 = workerData.Join(salaries, key1 => key1.taxpayerCardID, key2 => key2.taxpayerCardID, (key1, key2) => new { key1, key2 });
            foreach (var info in q9)
                Console.WriteLine($"{info.key1.personalID}. Hired: {info.key1.hiredDate.ToString("dd/MM/yyyy")}, spec: {info.key1.specialization}\t- {info.key2.salary}");

            Console.WriteLine("\nЗапит №10. Об'єднання об'єктів з виключенням дублікатів\n");

            List<PersonalInfo> unionData = new List<PersonalInfo>()
            {
                new PersonalInfo("Ponomarchuk", "Valentyna", "Romanivna",  DateTime.Parse("1969-08-17"), "Ph.D",     9),
                new PersonalInfo("NewSurname", "NewName", "NewMiddle", DateTime.Parse("1111-11-11"), "bachelor", 10)
            };
            var q10 = personalData.Union(unionData, new DataEqualityComparer());
            foreach (var person in q10)
                Console.WriteLine(person);

            Console.WriteLine("\nЗапит №11. Групування\n");

            var q11 = from person in personalData
                      group person by person.education;
            foreach (var group in q11) {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var person in group)
                    Console.WriteLine(person);
            }

            Console.WriteLine("\nЗапит №12. Групування з використанням Count\n");

            var q12 = from person in personalData
                      group person by person.education;
            foreach (var group in q12)
            {
                Console.Write($"Group: {group.Key} - ");
                Console.WriteLine(group.Count());
            }

            Console.WriteLine("\nЗапит №13. Групування методом розширення\n");

            var q13 = personalData.Join(workerData, key1=>key1.personalID, key2=>key2.personalID, (key1, key2)=> new{ ID = key1.personalID, Surname = key1.surname, specializaion = key2.specialization}).GroupBy(x => x.specializaion);
            foreach (var group in q13) {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var worker in group)
                    Console.WriteLine($"{worker.ID}. {worker.Surname}");
            }

            Console.WriteLine("\nЗапит №14. Використання Avarage\n");

            var q14 = from worker in workerData
                      join salary in salaries
                      on worker.taxpayerCardID equals salary.taxpayerCardID
                      group new { spec = worker.specialization, money = salary.salary } by worker.specialization into grouped
                      select new { specialization = grouped.Key, moneyAverage = grouped.Average(x => x.money) };
            foreach (var row in q14)
                    Console.WriteLine($"{row.specialization} - {row.moneyAverage} UAH");

            Console.WriteLine("\nЗапит №15. \n");

            var tableNewData = from salaryNew in salaries
                           where salaryNew.monthYear == DateTime.Parse("2021-11-01")
                           select salaryNew;
            var tableOldData = from salaryOld in salaries
                           where salaryOld.monthYear == DateTime.Parse("2021-10-01")
                           select salaryOld;
            var differenceTable = from salaryNew in tableNewData
                                  join salaryOld in tableOldData
                                  on salaryNew.taxpayerCardID equals salaryOld.taxpayerCardID
                                  where salaryOld.salary - salaryNew.salary <= 200
                                  select new { taxpayerCardID = salaryOld.taxpayerCardID, oldSalary = salaryOld, newSalary = salaryNew };
            var q15 = from people in personalData
                      join worker in workerData
                      on people.personalID equals worker.personalID into table1
                      from info1 in table1
                      join salary in differenceTable
                      on info1.taxpayerCardID equals salary.taxpayerCardID
                      select new { ID = people.personalID, surname = people.surname, education = people.education, info1.hiredDate, info1.specialization, salaryDiff = salary.oldSalary.salary - salary.newSalary.salary };
            foreach (var person in q15)
                Console.WriteLine($"{person.ID}. {person.surname}\thired {person.hiredDate.ToString("dd/MM/yyyy")} - education: {person.education},\tspecialization: {person.specialization}\t difference: {person.salaryDiff}");

            Console.ReadKey();
        }
    }
}
