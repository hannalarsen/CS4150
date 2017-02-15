using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumorMill
{
    public class Rumor : IComparer<Student>
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
            //r.RumorReport();
            foreach (string s in r.RumorReport())
            {
                Console.WriteLine(r);
            }
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
                    school.AddStudent(s1);
                }

                for (int i = 0; i < friends1.Count; i++)
                {
                    string f1 = friends1.ElementAt(i);
                    string f2 = friends2.ElementAt(i);
                    school.AddFriend(school.FindStudent(f1), school.FindStudent(f2));
                    school.AddFriend(school.FindStudent(f2), school.FindStudent(f1));
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
                BFS(school.FindStudent(r));
                List<Student> sorted = new List<Student>();
                foreach (Student s in school.GetStudents())
                {
                    sorted.Add(s);
                }
                // Sorts by distance from rumor starter
                sorted.Sort(Compare);
                
                school.GetStudents().Sort(Compare);
                foreach (Student s1 in sorted)
                {
                    rumorList = rumorList + s1.GetStudentName() + " ";
                }
                rumorReports.Add(rumorList);
                
            }

            return rumorReports;
        }



        private void BFS(Student r)
        {
            foreach (Student s in school.GetStudents())
            {
                s.SetDist(11000);
                s.SetPrev(null); 
            }
            r.SetDist(0);
            Queue<Student> q = new Queue<Student>();
            q.Enqueue(r);

            while (q.Count != 0)
            {
               Student u = q.Dequeue();
               foreach (Student v in school.GetFriends(u))
                {
                    if (v.GetDist() == 11000)
                    {
                        q.Enqueue(v);
                        v.SetDist(u.GetDist() + 1);
                        v.SetPrev(u);
                    }
                }
            }
        }

        public int Compare(Student x, Student y)
        {
            int c = x.GetDist().CompareTo(y.GetDist());
            if (c == 0)
            {
                c = x.GetStudentName().CompareTo(y.GetStudentName());
            }
            return c;
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
        private Student prev;
        private int dist;
        public Student(string n)
        {
            studentName = n;
            knows = false;
            prev = null;
            dist = 11000;
        }

        public string GetStudentName()
        {
            return studentName;
        }

        public bool DoesKnow()
        {
            return knows;
        }

        public void SetPrev(Student s1)
        {
            prev = s1;
            
        }

        public Student GetPrev()
        {
            return prev;
        }

        public void SetDist(int d)
        {
            dist = d;
        }
        public int GetDist()
        {
            return dist;
        }
    }
}
