﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace teamproject
{
    static class BlockValue
    {
        static public readonly int[,,,] bvals = new int[7, 4, 4, 4]
        {
            {
                {
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 1, 1, 1, 1 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 1, 1, 1, 1 },
                    { 0, 0, 0, 0 }
                }
            },
            {
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                }
            },
            {
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 },
                    { 0, 1, 1, 1 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 1 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 1 },
                    { 0, 1, 0, 0 }
                }
            },
            {
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 1 },
                    { 0, 0, 0, 1 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 1, 1, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 1, 1, 1 },
                    { 0, 0, 0, 0 }
                }
            },
            {
                {
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 1 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 1, 0 },
                    { 0, 1, 1, 1 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 }
                }
            },
            {
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 1, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 1, 0 }
                }
            },
            {
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 0, 1 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 0 }
                },
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 0, 1 }
                }
            }
        };
    }
}
