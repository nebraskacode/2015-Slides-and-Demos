using System;
using System.Windows.Forms;
using Aws.Core.Models;

namespace Aws.ControlPanel.Helpers
{
    public static class InstanceInfoExtensions
    {
        public static ListViewItem ToListViewItem(this InstanceInfo instanceInfo)
        {
            var lvi = new ListViewItem(new string[]
            {
                instanceInfo.InstanceId,
                instanceInfo.Status.ToString(),
                instanceInfo.IpAddress,
                "",
                "",
                ""
            });
            if (instanceInfo.WorkerInfo != null)
            {
                lvi.UpdateListViewItem(instanceInfo.WorkerInfo);
            }
            return lvi;
        }

        public static void UpdateListViewItem(this ListViewItem lvi, WorkerInfo workerInfo)
        {
            lvi.SubItems[3].Text = workerInfo.WorkerOnline ? "Online" : "Offline";
            lvi.SubItems[4].Text = workerInfo.WorkerVersion.ToString();
            lvi.SubItems[5].Text = workerInfo.WorkerLoad.ToString();
        }

        public static void UpdateListViewRow(this ListView lv, string instanceId, Action<ListViewItem> updateRowAction)
        {
            foreach (ListViewItem item in lv.Items)
            {
                if (item.SubItems[0].Text == instanceId)
                {
                    updateRowAction(item);
                }
            }
        }
    }
}