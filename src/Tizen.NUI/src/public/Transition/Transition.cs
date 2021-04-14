/*
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

namespace Tizen.NUI
{
    using System;
    using System.ComponentModel;
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Transition class is a cluster of properties for the transition of View Pair.
    /// Transition class will be used as a property of Navigator.Transition.
    /// During page Transition each of View pair those have same TransitionTag will be move with same Navigator.Transition property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Transition : TransitionBase
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transition()
        {
        }

        internal TransitionItem CreateTransition(View source, View destination)
        {
            TransitionItem transition= new TransitionItem(source, destination, TimePeriod, AlphaFunction);
            return transition;
        }
    }
}
