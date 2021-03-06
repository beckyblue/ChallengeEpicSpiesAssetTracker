﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //Keeps from re-initializing
            {
                // Initialize arrays
                string[] assets = new string[0];
                int[] elections = new int[0];
                int[] acts = new int[0];

                // Add to ViewState to save to server
                ViewState.Add("Assets", assets);
                ViewState.Add("Elections", elections);
                ViewState.Add("Acts", acts);
            }

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            // Retrieve the arrays to modify
            string[] assets = (string[])ViewState["Assets"];
            int[] elections = (int[])ViewState["Elections"];
            int[] acts = (int[])ViewState["Acts"];

            // Re-size the arrays
            int newLength = assets.Length + 1;

            Array.Resize(ref assets, newLength);
            Array.Resize(ref elections, newLength);
            Array.Resize(ref acts, newLength);

            // Holds values to the new Index
            int newIndex = assets.GetUpperBound(0);

            // add to index and updated
            assets[newIndex] = assetTextBox.Text;
            elections[newIndex] = int.Parse(electionsTextBox.Text);
            acts[newIndex] = int.Parse(actsTextBox.Text);

            // Save to the ViewState
            ViewState["Assets"] = assets;
            ViewState["Elections"] = elections;
            ViewState["Acts"] = acts;

            resultLabel.Text = String.Format("Total Elections Rigged: {0} <br/> Average Acts of Subterfuge per Asset: {1:N2} <br/> (Last Asset you Added: {2})",
                elections.Sum(), 
                acts.Average(), 
                assets[newIndex]);

            // Reset Text Boxes to empty
            assetTextBox.Text = "";
            electionsTextBox.Text = "";
            actsTextBox.Text = "";




        }
    }
}