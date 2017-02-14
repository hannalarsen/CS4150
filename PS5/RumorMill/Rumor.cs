using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumorMill
{
    public class Rumor
    {
        private List<string> students;
        private List<string> friends1;
        private List<string> friends2;
        private List<string> rumorStarters;
        private School school;
         
        public static void Main(string[] args)
        {
            Rumor r = new Rumor();
            r.GetInfo();
            r.CreateSchool();
        }

        public void GetInfo()
        {
            students = new List<string>();
            friends1 = new List<string>();
            friends2 = new List<string>();
            rumorStarters = new List<string>();
            int n = 0;
            int ncount = 0;
            int f = 0;
            int fcount = 0;
            int r = 0;
            int rcount = 0;
            
            try
            {
                string line = "";
                char[] spaces = { ' ' };
                string[] currentLine;
                
                while ((line = Console.ReadLine()) != null && line.Length > 0)
                {
                    currentLine = line.Split(spaces);

                    // Number of students
                    if (ncount == 0)
                    {
                        n = Convert.ToInt32(currentLine[0]);
                        ncount++;
                    }
                    else if (ncount <= n)
                    {
                        students.Add(currentLine[0]);
                        ncount++;
                    }

                    else if (ncount == n + 1)
                    {
                        f = Convert.ToInt32(currentLine[0]);
                        if (f == 0)
                        {
                            ncount++;
                            continue;
                        }
                        ncount++;
                    }

                    // Number of friendships
                    else if(ncount > n + 1 && fcount < f)
                    {
                        string f1 = currentLine[0];
                        string f2 = currentLine[1];
                        friends1.Add(f1);
                        friends2.Add(f2);
                        fcount++;
                    }

                    // Number of rumors
                    else if (fcount == f)
                    {
                        r = Convert.ToInt32(currentLine[0]);
                        fcount++;
                    }

                    else if (fcount > f && rcount < r)
                    {
                        rumorStarters.Add(currentLine[0]);
                        rcount++;
                    }
                }

            }
            catch (Exception e)
            { }

        }

        public void CreateSchool()
        {
            try
            {
                school = new School();
                // Adds vertices
                foreach (string s in students)
                {
                    Student s1 = new Student(s);
                }

                for (int i = 0; i < friends1.Count; i++)
                {
                    string f1 = friends1.ElementAt(i);
                    string f2 = friends2.ElementAt(i);
                    school.AddFriend(school.FindStudent(f1), school.FindStudent(f2));
                }
            }
            catch (Exception e)
            { };
        }

        public List<string> RumorReport()
        {
            List<string> rumorReports = new List<string>();
            foreach (string r in rumorStarters)
            {
                string rumorList = "";
                BFS(r);
            }

            return rumorReports;
        }

        private void BFS(Student r)
        {
            double[] dist = new double[school.GetStudents().Count];
            Student[] prev = new Student[school.GetStudents().Count];

            for (int i = 0; i < school.GetStudents().Count; i++)
            {
                dist[i] = double.PositiveInfinity;
                prev[i] = null;
            }

            dist[0] = 0;
            Queue<Student> q = new Queue<Student>();
            q.Enqueue(r);

            while (q.Count != 0)
            {
                Student u = q.Dequeue();
                for (int i = 0; i < school.GetFriends(u).Count; i++)
                {

                }
            }
        }
    }






    public class School
    {
        Dictionary<Student, List<Student>> s;
        public School()
        {
            s = new Dictionary<Student, List<Student>>();
        }

        public List<Student> GetStudents()
        {
            return s.Keys.ToList();
        }
        
        public List<Student> GetFriends(Student s1)
        {
            List<Student> value;
            s.TryGetValue(s1, out value);
            return value;
        }

        public Student FindStudent(string name)
        {
            foreach(Student st in s.Keys)
            {
                if (st.GetStudentName() == name)
                {
                    return st;
                }
            }
            return null;
        }

        public void AddFriend(Student s1, Student s2)
        {
            List<Student> value;
            s.TryGetValue(s1, out value);
            value.Add(s2);
        }

        public void AddStudent(Student s1)
        {
            s.Add(s1, new List<Student>());
        }
    }

    public class Student
    {
        private string studentName;
        private bool knows;
        public Student(string n)
        {
            studentName = n;
            knows = false;
        }

        public string GetStudentName()
        {
            return studentName;
        }

        public bool DoesKnow()
        {
            return knows;
        }
    }
}
