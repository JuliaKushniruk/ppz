using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebSite.Models
{
    public class Cinema
    {
        private string name;
        private string description;
        private string address;
        private Seats seats;
        private List<Event> events;
    }

    public class Seats
    {
        private int rows;
        private int columns;

        public Seats(int _rows, int _columns)
        {
            rows = _rows;
            columns = _rows;
        }

        public int Rows { get { return rows; } }
        public int Columns { get { return columns; } }
        public int Count {  get { return rows * columns; } }
    }
}