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
using Android.Support.V7.Widget;
using StaggeredLayoutParams = Org.Lucasr.TwoWayView.Widget.StaggeredGridLayoutManager.LayoutParams;

namespace Org.Lucasr.TwoWayView.Sample
{
    public class MyRecyclerViewAdapter : RecyclerView.Adapter
    {

        private int _count;
        private readonly Context _context;

        private class SimpleViewHolder : RecyclerView.ViewHolder
        {
            public TextView Title { get; private set; }

            public SimpleViewHolder(View view)
                : base(view)
            {
                Title = (TextView)view.FindViewById(Resource.Id.title);
            }
        }

        public MyRecyclerViewAdapter(Context context, int count)
        {
            _count = count;
            _context = context;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new SimpleViewHolder(LayoutInflater.From(_context).Inflate(Resource.Layout.Item, parent, false));
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var layoutParameters = holder.ItemView.LayoutParameters as StaggeredLayoutParams;

            layoutParameters.Span = position % 3 == 0 ? 2 : 1;
            holder.ItemView.LayoutParameters = layoutParameters;

            (holder as SimpleViewHolder).Title.Text = position.ToString();
        }

        public override int ItemCount
        {
            get { return _count; }
        }

    }
}