﻿//
//  Copyright 2016  R. Stanley Hum <r.stanley.hum@gmail.com>
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandbookApp.States;
using Xamarin.Forms;
using System.Reactive.Linq;

namespace HandbookApp.Views
{
    public partial class MainSection : ContentView
    {
        public MainSection()
        {
            InitializeComponent();

            App.Store
                .Subscribe(state => {
                    Device.BeginInvokeOnMainThread(() => {
                        //ArticleItemsControl.ItemsSource = state.Articles.Values.OrderBy(x => x.Id);
                        setStackLayoutChildren(state.Articles.Values.OrderBy(x => x.Id));
                    });
                });
        }

        private void setStackLayoutChildren(IEnumerable<Article> values)
        {
            var elements = values
                .Select(x => new StackLayout {
                    Orientation = StackOrientation.Vertical,
                    Children = {
                        new Label {
                            Text = x.Id
                        },
                        new Label {
                            Text = x.Title
                        }
                    }
                });
            articlesSL.Children.Clear();
            foreach (var e in elements)
            {
                articlesSL.Children.Add(e);
            }
        }
    }
}
