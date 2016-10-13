using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IssueSystem
{
    class Beautiful
    {
            public const Int32 AW_HOR_POSITIVE = 0x00000001;    // 从左到右打开窗口
            public const Int32 AW_HOR_NEGATIVE = 0x00000002;    // 从右到左打开窗口
            public const Int32 AW_VER_POSITIVE = 0x00000004;    // 从上到下打开窗口
            public const Int32 AW_VER_NEGATIVE = 0x00000008;    // 从下到上打开窗口
            public const Int32 AW_CENTER = 0x00000010;
            public const Int32 AW_HIDE = 0x00010000;        // 在窗体卸载时若想使用本函数就得加上此常量
            public const Int32 AW_ACTIVATE = 0x00020000;    //在窗体通过本函数打开后，默认情况下会失去焦点，除非加上本常量
            public const Int32 AW_SLIDE = 0x00040000;
            public const Int32 AW_BLEND = 0x00080000;       // 淡入淡出效果
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool AnimateWindow(
            IntPtr hwnd, // handle to window    
            int dwTime, // duration of animation    
            int dwFlags // animation type    
            );
        }

           /*淡入窗体*/
        //private void Form_Load(object sender, EventArgs e)
        //{
        //        Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);
        //}
        ///*淡出窗体*/
        //private void Form_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Win32.AnimateWindow(this.Handle, 2000, Win32.AW_SLIDE | Win32.AW_HIDE | Win32.AW_BLEND);
        //}
    
}
