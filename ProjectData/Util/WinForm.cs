﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectData.Util
{
    public class WinForm
    {
        public static Form current;

        /// <summary>
        /// Opens a new Form on the location of the current one and closes the old one.
        /// </summary>
        /// <typeparam name="T">Instance of Form</typeparam>
        /// <param name="currentForm">The current form that is open</param>
        /// <returns>The new open form</returns>
        public static T OpenForm<T>(Form currentForm) where T : Form, new()
        {
            T result = new T
            {
                Location = currentForm.Location,
                StartPosition = FormStartPosition.Manual
            };

            result.Show();
            currentForm.Hide();

            current = result;

            return result;
        }

        /// <summary>
        /// Execute methods on the main thread.
        /// </summary>
        /// <param name="methods">Methods that need to be executed on the main thread</param>
        public static void Execute(params Action[] methods)
        {
            if (current.InvokeRequired)
            {
                current.Invoke((MethodInvoker)delegate ()
                {
                    //Execute on main thread
                    foreach(Action method in methods)
                    {
                        method();
                    }
                });
            }
        }
    }
}
