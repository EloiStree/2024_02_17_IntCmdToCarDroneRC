using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCmdToDroneCarDefaultMono : MonoBehaviour
{

    public IntCmdToDroneCarDefault m_value;

    public void Set(IntCmd intValue)
    {

        m_value.Set(intValue.GetValue());
    }
    public void Set(int intValue)
    {

        m_value.Set(intValue);
    }
    //public void Refresh()
    //{ 

    //    if (m_source == null)
    //        return;
    //    m_value.m_commandTypeIsDrone = m_source.m_value.GetCommandDigitType() == 1;
    //    if (m_value.m_commandTypeIsDrone)
    //    {

    //    }
    //    else
    //    {
    //        m_value.m_requestAction = false;
    //        m_value.m_requestActionIsGeneric = false;
    //        m_value.m_commandTypeIsDrone = false;
    //        m_value.m_actionDigit = 0;
    //        m_value.m_percentCarLeftFront = 0;
    //        m_value.m_percentCarRightFront = 0;
    //        m_value.m_percentCarLeftBack = 0;
    //        m_value.m_percentCarRightBack = 0;
    //        m_value.m_percentDroneLeftFront = 0;
    //        m_value.m_percentDroneRightFront = 0;
    //        m_value.m_percentDroneLeftBack = 0;
    //        m_value.m_percentDroneRightBack = 0;

    //    }
    //}

}
[System.Serializable]
public class IntCmdToDroneCarDefault
{
    public IntCmd m_intValue= new IntCmd();
    public IntCmdDigits m_intValueAsDigit = new IntCmdDigits();
    public IntCmdAsChar m_intChar = new IntCmdAsChar();

    public IntCmdToBinaryBools m_intBinary = new IntCmdToBinaryBools();
    public IntCmdToDroneCarDigits m_carDroneDigits = new IntCmdToDroneCarDigits();
    public IntCmdToDroneCarInput m_carDroneInput = new IntCmdToDroneCarInput();

    public void Set(in int intCmd)
    {
        
        IntCmdUtility.Convert( intCmd, out m_intValue);
        IntCmdUtility.Convert( intCmd, out m_intValueAsDigit);
        IntCmdUtility.Convert( intCmd, out m_intChar);
        IntCmdUtility.Convert( intCmd, out m_intBinary);
        IntCmdCarDroneUtility.Convert(intCmd, out m_carDroneDigits);
        IntCmdCarDroneUtility.Convert(intCmd, out m_carDroneInput);
    }
 
}

[System.Serializable]
public class IntCmdToDroneCarInput
{
    public CommandType m_commandDigit;
    [Range(0, 1f)]
    public float m_percentCarLeftFront;
    [Range(0, 1f)]
    public float m_percentCarRightFront;
    [Range(0, 1f)]
    public float m_percentCarLeftBack;
    [Range(0, 1f)]
    public float m_percentCarRightBack;
    [Range(-1f, 1f)]
    public float m_percentDroneLeftFront;
    [Range(-1f, 1f)]
    public float m_percentDroneRightFront;
    [Range(-1f, 1f)]
    public float m_percentDroneLeftBack;
    [Range(-1f, 1f)]
    public float m_percentDroneRightBack;
    public DigitAction m_actionDigit;  
}


public enum DigitAction : byte { None, GenericAction, CustomAction0, CustomAction1, CustomAction2, CustomAction3, CustomAction4, CustomAction5, CustomAction6, CustomAction7 }
public enum CommandType : short { Int2_CarDroneBinary=2, Int1_CarDroneInput = 1, NInt1_CharInput=-1, NInt2_CustomCommand=-2 }
