using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections;

namespace SimpleCrudXamarinAndroid
{
    class CRUD
    {
        ArrayList players;
        ArrayAdapter adapter;

        public CRUD(ArrayList players, ArrayAdapter adapter)
        {
            this.players = players;
            this.adapter = adapter;
        }

        public Boolean Add(String name)
        {
            try
            {
                players.Add(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Update(String newName, int id)
        {
            try
            {
                players.RemoveAt(id);
                players.Insert(id, newName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Delete (int id)
        {
            try
            {
                players.RemoveAt(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Clear()
        {
            players.Clear();
        }
    }
}