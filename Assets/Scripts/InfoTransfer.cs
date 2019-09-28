using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfoTransfer
{
    private static Character character;
    private static Taxation taxation;

    public static Character Character
    {
        get
        {
            return character;
        }
        set
        {
            character = value;
        }
    }

    public static Taxation Taxation
    {
        get
        {
            return taxation;
        }
        set
        {
            taxation = value;
        }
    }
}
