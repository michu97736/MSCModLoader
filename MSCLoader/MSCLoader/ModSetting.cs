﻿using System;
using UnityEngine.UI;

namespace MSCLoader;

/// <summary>
/// Mod Setting base class
/// </summary>
public class ModSetting
{
    internal string ID;
    internal string Name;
    internal Action DoAction;
    internal SettingsType SettingType;

    internal SettingsElement SettingsElement;
    internal SettingsGroup HeaderElement;
    internal ModSetting(string id, string name, Action doAction, SettingsType type)
    {
        ID = id;
        Name = name;
        DoAction = doAction;
        SettingType = type;
    }
   /* internal void SetElements(SettingsElement settingsElement, SettingsGroup header)
    {
        SettingsElement = settingsElement;
        HeaderElement = header;
    }*/
    internal void UpdateName(string name)
    {
        Name = name;
        if (SettingsElement == null) return;
        if (SettingsElement.settingName != null)
        {
            SettingsElement.settingName.text = Name;
        }
    }
    internal void UpdateValue(object Value)
    {
        if (SettingsElement == null) return;
        if (SettingsElement.value != null)
        {
            switch (SettingType)
            {
                case SettingsType.TextBox:
                    SettingsElement.textBox.text = Value.ToString();
                    break;
                case SettingsType.DropDown:
                    SettingsElement.dropDownList.SelectedIndex = int.Parse(Value.ToString());
                    break;
                default:
                    SettingsElement.value.text = Value.ToString();
                    break;
            }
        }
    }
}


/// <summary>
/// Settings checkbox
/// </summary>
public class SettingsCheckBox : ModSetting
{
    internal bool Value = false;
    internal bool DefaultValue = false;
    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get checkbox value
    /// </summary>
    /// <returns>true/false</returns>
    public bool GetValue()
    {
        return Value;
    }

    /// <summary>
    /// Set checkbox value
    /// </summary>
    /// <param name="value">true/false</param>
    public void SetValue(bool value)
    {
        Value = value;
        UpdateValue(value);
    }

    internal SettingsCheckBox(string id, string name, bool value, Action doAction) : base(id, name, doAction, SettingsType.CheckBox)
    {
        Value = value;
        DefaultValue = value;
       // Instance = setting;
    }
}

/// <summary>
/// CheckBox group (aka radio button)
/// </summary>
public class SettingsCheckBoxGroup : ModSetting
{
    internal bool Value = false;
    internal bool DefaultValue = false;
    internal string CheckBoxGroup = string.Empty;
    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get checkbox value
    /// </summary>
    /// <returns>true/false</returns>
    public bool GetValue()
    {
        return Value;
    }

    /// <summary>
    /// Set checkbox value
    /// </summary>
    /// <param name="value">true/false</param>
    public void SetValue(bool value)
    {
        Value = value;
        UpdateValue(value);
    }
    internal SettingsCheckBoxGroup(string id, string name, bool value, string group, Action doAction) : base(id, name, doAction, SettingsType.CheckBoxGroup)
    {
        Value = value;
        DefaultValue = value;
        CheckBoxGroup = group;
       // Instance = setting;
    }
}

/// <summary>
/// Integer version of Settings Slider
/// </summary>
public class SettingsSliderInt : ModSetting
{
    internal int Value = 0;
    internal int DefaultValue = 0;
    internal int MinValue = 0;
    internal int MaxValue = 100;
    internal string[] TextValues = null;
    
    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get slider value
    /// </summary>
    /// <returns>slider value in int</returns>
    public int GetValue()
    {
        return Value;
    }

    /// <summary>
    /// Set value for slider
    /// </summary>
    /// <param name="value">value</param>
    public void SetValue(int value)
    {
        Value = value;
        UpdateValue(value);
    }

    internal SettingsSliderInt(string id, string name, int value, int minValue, int maxValue,  Action onValueChanged, string[] textValues) : base(id, name, onValueChanged, SettingsType.SliderInt)
    {
        Value = value;
        DefaultValue = value;
        MinValue = minValue;
        MaxValue = maxValue;
        TextValues = textValues;
      //  Instance = s;
    }
}

/// <summary>
/// Settings Slider
/// </summary>
public class SettingsSlider : ModSetting
{
    internal float Value = 0;
    internal float DefaultValue = 0;
    internal float MinValue = 0;
    internal float MaxValue = 100;
    internal int DecimalPoints = 0;
    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get slider value
    /// </summary>
    /// <returns>slider value in float</returns>
    public float GetValue()
    {
        return Value;
    }

    /// <summary>
    /// Set value for slider
    /// </summary>
    /// <param name="value">value</param>
    public void SetValue(float value)
    {
        Value = value;
        UpdateValue(value);
    }

    internal SettingsSlider(string id, string name, float value, float minValue, float maxValue, Action onValueChanged, int decimalPoints) : base(id, name, onValueChanged, SettingsType.Slider)
    {   
        Value = value;
        DefaultValue = value;
        MinValue = minValue;
        MaxValue = maxValue;
        DecimalPoints = decimalPoints;
     //   Instance = s;
    }
}

/// <summary>
/// Settings TextBox
/// </summary>
public class SettingsTextBox : ModSetting
{
    internal string Value = string.Empty;
    internal string DefaultValue = string.Empty;
    internal string Placeholder = string.Empty;
    internal InputField.ContentType ContentType = InputField.ContentType.Standard;

    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get TextBox value
    /// </summary>
    /// <returns>TextBox string value</returns>
    public string GetValue()
    {
        return Value;
    }

    /// <summary>
    /// Set value for textbox
    /// </summary>
    /// <param name="value">value</param>
    public void SetValue(string value)
    {
        Value = value;
        UpdateValue(value);
    }

    internal SettingsTextBox(string id, string name, string value, string placeholder, InputField.ContentType contentType) : base(id, name, null, SettingsType.TextBox)
    {
        Value = value;
        DefaultValue = value;
        Placeholder = placeholder;
        ContentType = contentType;
      //  Instance = s;
    }
}
/// <summary>
/// Settings DropDown List
/// </summary>
public class SettingsDropDownList : ModSetting
{
    internal int Value = 0;
    internal string[] ArrayOfItems = new string[0];
    internal int DefaultValue = 0;

    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get DropDownList selected Item Index (can be accessed from anywhere)
    /// </summary>
    /// <returns>DropDownList selectedIndex as int</returns>
    public int GetSelectedItemIndex()
    {
        return Value;
    }

    /// <summary>
    /// Get DropDownList selected Item Name (Only possible if settings are open).
    /// </summary>
    /// <returns>DropDownList selected item name as string</returns>
    public string GetSelectedItemName()
    {
        return ArrayOfItems[Value];
    }

    /// <summary>
    /// Set DropDownList selected Item Index
    /// </summary>
    /// <param name="value">index</param>
    public void SetSelectedItemIndex(int value)
    {
        Value = value;
        UpdateValue(value);
    }

    internal SettingsDropDownList(string id, string name, string[] arrayOfItems, int defaultValue, Action onSelectionChanged) : base(id, name, onSelectionChanged, SettingsType.DropDown)
    {
        Value = defaultValue;
        ArrayOfItems = arrayOfItems;
        DefaultValue = defaultValue;
     //   Instance = s;
    }
}
/// <summary>
/// Settings Color Picker
/// </summary>
public class SettingsColorPicker : ModSetting
{
    internal string Value = "0,0,0,255";
    internal string DefaultColorValue = "0,0,0,255";
    internal bool ShowAlpha = false;
    /// <summary>
    /// Settings Instance (used for custom reset button)
    /// </summary>
    public Settings Instance;

    /// <summary>
    /// Get Color32 value
    /// </summary>
    /// <returns>TextBox string value</returns>
    public Color32 GetValue()
    {
        string[] colb = Value.Split(',');
        return new Color32(byte.Parse(colb[0]), byte.Parse(colb[1]), byte.Parse(colb[2]), byte.Parse(colb[3]));
    }

    /// <summary>
    /// Set Color32 value
    /// </summary>
    /// <param name="col">value</param>
    public void SetValue(Color32 col)
    {
        Value = $"{col.r},{col.g},{col.b},{col.a}";
    }


    internal SettingsColorPicker(string id, string name, Color32 defaultColor, bool showAlpha, Action onColorChanged) : base(id, name, onColorChanged, SettingsType.ColorPicker)
    {
        Value = $"{defaultColor.r},{defaultColor.g},{defaultColor.b},{defaultColor.a}";
        DefaultColorValue = $"{defaultColor.r},{defaultColor.g},{defaultColor.b},{defaultColor.a}";
        ShowAlpha = showAlpha;
      //  Instance = s;
    }
}

/// <summary>
/// Settings Header
/// </summary>
public class SettingsHeader : ModSetting
{
    internal Color BackgroundColor = new Color32(95, 34, 18, 255);
    internal Color TextColor = new Color32(236, 229, 2, 255);
    internal bool CollapsedByDefault = false;

    /// <summary>
    /// Collapse this header
    /// </summary>
    public void Collapse() => Collapse(false);

    /// <summary>
    /// Collapse this header without animation
    /// </summary>
    /// <param name="skipAnimation">true = skip collapsing animation</param>
    public void Collapse(bool skipAnimation)
    {
        if (HeaderElement == null) return;
        if (skipAnimation)
        {
            HeaderElement.SetHeaderNoAnim(false);
            return;
        }
        HeaderElement.SetHeader(false);
    }

    /// <summary>
    /// Expand this Header
    /// </summary>
    public void Expand() => Expand(false);

    /// <summary>
    /// Expand this Header without animation
    /// </summary>
    /// <param name="skipAnimation">true = skip expanding animation</param>
    public void Expand(bool skipAnimation)
    {
        if (HeaderElement == null) return;
        if (skipAnimation)
        {
            HeaderElement.SetHeaderNoAnim(true);
            return;
        }
        HeaderElement.SetHeader(true);

    }

    /// <summary>
    /// Change title background color
    /// </summary>
    public void SetBackgroundColor(Color color)
    {
        if (HeaderElement == null) return;
        HeaderElement.HeaderBackground.color = color;
    }

    /// <summary>
    /// Change title text.
    /// </summary>
    public void SetTextColor(Color color)
    {
        if (HeaderElement == null) return;
        HeaderElement.HeaderTitle.color = color;
    }


    internal SettingsHeader(string name, Color backgroundColor, Color textColor, bool collapsedByDefault) : base(null, name, null, SettingsType.Header)
    { 
        BackgroundColor = backgroundColor;
        TextColor = textColor;
        CollapsedByDefault = collapsedByDefault;
    }
}

/// <summary>
/// Settings Text
/// </summary>
public class SettingsText : ModSetting
{   
    /// <summary>
     /// Get Text value
     /// </summary>
     /// <returns>TextBox string value</returns>
    public string GetValue()
    {
        return Name;
    }

    /// <summary>
    /// Set value for textbox
    /// </summary>
    /// <param name="value">value</param>
    public void SetValue(string value)
    {
        UpdateValue(value);
    }

    internal SettingsText(string name) : base(null, name, null, SettingsType.Text) { }

}

/// <summary>
/// Settings Button 
/// </summary>
public class SettingsButton : ModSetting
{
    internal Color BackgroundColor = new Color32(85, 38, 0, 255);
    internal Color TextColor = Color.white;

    internal SettingsButton(string name, Action doAction, Color backgroundColor, Color textColor) : base(null, name, doAction, SettingsType.Button)
    { 
        BackgroundColor = backgroundColor;
        TextColor = textColor;
    }
}


/// <summary>
/// Settings Dynamic Header
/// </summary>
[Obsolete("Moved to => SettingsHeader",true)]
public class SettingsDynamicHeader : ModSetting
{
    internal Color BackgroundColor = new Color32(95, 34, 18, 255);
    internal Color TextColor = new Color32(236, 229, 2, 255);
    internal bool CollapsedByDefault = false;

    /// <summary>
    /// Collapse this header
    /// </summary>
    public void Collapse() => Collapse(false);

    /// <summary>
    /// Collapse this header without animation
    /// </summary>
    /// <param name="skipAnimation">true = skip collapsing animation</param>
    public void Collapse(bool skipAnimation)
    {
        if (HeaderElement == null) return;
        if (skipAnimation)
        {
            HeaderElement.SetHeaderNoAnim(false);
            return;
        }
        HeaderElement.SetHeader(false);
    }

    /// <summary>
    /// Expand this Header
    /// </summary>
    public void Expand() => Expand(false);

    /// <summary>
    /// Expand this Header without animation
    /// </summary>
    /// <param name="skipAnimation">true = skip expanding animation</param>
    public void Expand(bool skipAnimation)
    {
        if (HeaderElement == null) return;
        if (skipAnimation)
        {
            HeaderElement.SetHeaderNoAnim(true);
            return;
        }
        HeaderElement.SetHeader(true);

    }

    /// <summary>
    /// Change title background color
    /// </summary>
    public void SetBackgroundColor(Color color)
    {
        if (HeaderElement == null) return;
        HeaderElement.HeaderBackground.color = color;
    }

    /// <summary>
    /// Change title text.
    /// </summary>
    public void SetTextColor(Color color)
    {
        if (HeaderElement == null) return;
        HeaderElement.HeaderTitle.color = color;
    }


    internal SettingsDynamicHeader(string name, Color backgroundColor, Color textColor, bool collapsedByDefault) : base(null, name, null, SettingsType.Header)
    {
        BackgroundColor = backgroundColor;
        TextColor = textColor;
        CollapsedByDefault = collapsedByDefault;
    }
}

/// <summary>
/// Settings Dynamic Text
/// </summary>
[Obsolete("Moved to => SettingsText", true)]
public class SettingsDynamicText : ModSetting
{
    /// <summary>
    /// Get Text value
    /// </summary>
    /// <returns>TextBox string value</returns>
    public string GetValue()
    {
        return Name;
    }

    /// <summary>
    /// Set value for textbox
    /// </summary>
    /// <param name="value">value</param>
    public void SetValue(string value)
    {
        UpdateValue(value);
    }

    internal SettingsDynamicText(string name) : base(null, name, null, SettingsType.Text) { }
}

