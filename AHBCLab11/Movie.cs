using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AHBCLab11
{
    class Movie : IComparable<Movie>, IEquatable<Movie>
    {
        private string _title;
        private string _category;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public Movie(string title, string category)
        {
            _title = title;
            _category = category;
        }

        public int CompareTo(Movie next)
        {
            return String.Compare(this.Title, next.Title);
        }

        public bool Equals(Movie other)
        {
            if (this.Title.Equals(other.Title, StringComparison.CurrentCultureIgnoreCase))
                return true;
            else return false;
        }
    }
}
