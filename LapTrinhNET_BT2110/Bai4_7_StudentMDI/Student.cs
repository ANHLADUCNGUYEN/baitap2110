using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bai4_7_StudentMDI
{
    public class Student : INotifyPropertyChanged
    {
        private string studentId = string.Empty;
        private string fullName = string.Empty;
        private int age;
        private string gender = "Nam";
        private string avatarPath = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string StudentId
        {
            get => studentId;
            set
            {
                if (studentId != value)
                {
                    studentId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FullName
        {
            get => fullName;
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AvatarPath
        {
            get => avatarPath;
            set
            {
                if (avatarPath != value)
                {
                    avatarPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public Student()
        {
        }

        public Student(string studentId, string fullName, int age, string gender, string avatarPath = "")
        {
            StudentId = studentId;
            FullName = fullName;
            Age = age;
            Gender = gender;
            AvatarPath = avatarPath;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
