using Android.App;
using Android.Widget;
using Android.OS;
using Org.Jsoup.Nodes;
using Org.Jsoup;
using Org.Jsoup.Select;
using System;
using Android.Util;

namespace JsoupSample
{
    [Activity(Label = "JsoupSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView textView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);

                textView = FindViewById<TextView>(Resource.Id.HtmlTextView);
                new JsoupServerCall(this).Execute();
            }
            catch (Exception ex)
            {

            }
        }

        private class JsoupServerCall : AsyncTask
        {
            MainActivity activity;
            public JsoupServerCall(MainActivity activity)
            {
                this.activity = activity;
            }
            protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
            {
                Document doc = Jsoup.Connect("https://androidmads.blogspot.in/").Get();
                Element link = doc.Select("img").First();
                return link.AbsUrl("src");
            }

            protected override void OnPostExecute(Java.Lang.Object result)
            {
                base.OnPostExecute(result);
                activity.textView.Text = result + "";
            }
        }
    }
}

