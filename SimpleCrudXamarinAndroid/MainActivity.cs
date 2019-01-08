using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Collections;
using System;

namespace SimpleCrudXamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ArrayList names;
        ListView listView1;
        ArrayAdapter adapter;
        CRUD crud;
        EditText txtName;
        Button btnAdd, btnUpdate, btnDelete, btnClear;
        int selectedItem = -1;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            txtName = FindViewById<EditText>(Resource.Id.txtName);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnClear = FindViewById<Button>(Resource.Id.btnClear);

            names = new ArrayList();

            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
            listView1.Adapter = adapter;

            crud = new CRUD(names, adapter);

            listView1.ItemClick += ListView1_ItemClick;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            crud.Clear();
            txtName.Text = "";
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
            listView1.Adapter = adapter;
            Toast.MakeText(this, "Button Clear Pressed", ToastLength.Short).Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (crud.Delete(selectedItem))
            {
                txtName.Text = "";
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
                listView1.Adapter = adapter;
                Toast.MakeText(this, "Button Delete Pressed", ToastLength.Short).Show();
            }
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (crud.Add(txtName.Text))
            {
                txtName.Text = "";
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
                listView1.Adapter = adapter;
                Toast.MakeText(this, "Button Add Pressed", ToastLength.Short).Show();
            }            
        }

        private void ListView1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            this.selectedItem = e.Position;
            txtName.Text = names[selectedItem].ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (crud.Update(txtName.Text, selectedItem))
            {
                txtName.Text = "";
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
                listView1.Adapter = adapter;
                Toast.MakeText(this, "Button Update Pressed", ToastLength.Short).Show();
            }
        }
    }
}