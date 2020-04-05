﻿using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Свойства
        public string Name { get; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }
        //AddYears
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка на ввод корректных входных данных
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));

            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата рождения.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен 0.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));

            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " - " + Age;
        }
    }
}
