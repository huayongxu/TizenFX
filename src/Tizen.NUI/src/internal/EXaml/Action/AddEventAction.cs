﻿/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.EXaml
{
    internal class AddEventAction : Action
    {
        public AddEventAction(Action parent)
        {
            this.parent = parent;
        }

        private Action parent;

        public Action DealChar(char c)
        {
            switch (c)
            {
                case ' ':
                case '\n':
                case '\r':
                    break;

                case '(':
                    childOp = new GetValueListAction(')', this);
                    return childOp;

                case '#':
                    parent?.OnActive();
                    return parent;
            }

            return this;
        }

        private GetValueListAction childOp;

        public void Init()
        {
            childOp = null;
        }

        public void OnActive()
        {
            if (null != childOp)
            {
                int instanceIndex = (childOp.ValueList[0] as Instance).Index;
                int elementIndex = (childOp.ValueList[1] as Instance).Index;
                int propertyIndex = (int)childOp.ValueList[2];
                int value = (int)childOp.ValueList[3];
                LoadEXaml.Operations.Add(new AddEvent(instanceIndex, elementIndex, propertyIndex, value));
            }
        }
    }
}
