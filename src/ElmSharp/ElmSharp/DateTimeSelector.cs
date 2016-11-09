/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    public enum DateTimeFieldType
    {
        Year,
        Month,
        Date,
        Hour,
        Minute,
        AmPm
    }

    public class DateTimeSelector : Layout
    {
        SmartEvent _changed;
        DateTime _cacheDateTime;

        public DateTimeSelector(EvasObject parent) : base(parent)
        {
            _changed = new SmartEvent(this, "changed");
            _changed.On += (s, e) =>
            {
                DateTime newDateTime = DateTime;
                DateTimeChanged?.Invoke(this, new DateChangedEventArgs(_cacheDateTime, newDateTime));
                DateTime = newDateTime;
            };
        }

        public event EventHandler<DateChangedEventArgs> DateTimeChanged;

        public string Format
        {
            get
            {
                return Interop.Elementary.elm_datetime_format_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_datetime_format_set(Handle, value);
            }
        }

        public DateTime MaximumDateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_max_get(Handle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_max_set(Handle, ref tm);
            }
        }

        public DateTime MinimumDateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_min_get(Handle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_min_set(Handle, ref tm);
            }
        }

        public DateTime DateTime
        {
            get
            {
                var tm = new Interop.Libc.SystemTime();
                Interop.Elementary.elm_datetime_value_get(Handle, ref tm);
                return tm;
            }
            set
            {
                Interop.Libc.SystemTime tm = value;
                Interop.Elementary.elm_datetime_value_set(Handle, ref tm);
                _cacheDateTime = value;
            }
        }

        public bool IsFieldVisible(DateTimeFieldType type)
        {
            return Interop.Elementary.elm_datetime_field_visible_get(Handle, (int)type);
        }

        public void SetFieldLimit(DateTimeFieldType type, int minimum, int maximum)
        {
            Interop.Elementary.elm_datetime_field_limit_set(Handle, (int)type, minimum, maximum);
        }

        public void SetFieldVisible(DateTimeFieldType type, bool visible)
        {
            Interop.Elementary.elm_datetime_field_visible_set(Handle, (int)type, visible);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_datetime_add(parent.Handle);
        }
    }
}
