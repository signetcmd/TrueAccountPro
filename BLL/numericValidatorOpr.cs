

//nabeel ali
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BLL
{
   public class NumericValidatorInfo
    {
        #region Public Members

        /// <summary>
        /// Restricts key press for integer fields based on the allowed keys and
        /// given number of digits. + and - signs are not allowed.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentValue">Current value of the field</param>
        /// <param name="insertionIndex">Index where the new value will get inserted.</param>
        /// <param name="maxDigits">Maximum number of digits allowed in the integer.</param>
        public static void RestrictInteger(ref KeyEventArgs e, string currentValue, int insertionIndex, int maxDigits)
        {
            RestrictInteger(ref e, currentValue, insertionIndex, maxDigits, false);
        }

        /// <summary>
        /// Restricts key press for integer fields based on the allowed keys and
        /// given number of digits.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentValue">Current value of the field</param>
        /// <param name="insertionIndex">Index where the new value will get inserted.</param>
        /// <param name="maxDigits">Maximum number of digits allowed in the integer.</param>
        /// <param name="allowSign">If true, allows + and - signs; otherwise will not allow.</param>
        public static void RestrictInteger(ref KeyEventArgs e, string currentValue, int insertionIndex, int maxDigits, bool allowSign)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e", "The KeyEventArgs object passed in is null.");
            }

            if (insertionIndex < 0)
            {
                throw new ArgumentException("The insertionIndex passed in is invalid.", "insertionIndex");
            }

            if (maxDigits < 0)
            {
                throw new ArgumentException("The maxDigits passed in is invalid.", "maxDigits");
            }

            if (e.Alt == true)
            {
                // Allowing the key press when Alt is pressed.
                return;
            }

            if (e.Control == true)
            {
                if (e.KeyCode == Keys.V)
                {
                    // Not allowing paste operation (Ctrl+v), as the current validation does not take care of this.
                    SuppressKey(e);

                    // To Do: instead of suppressing paste,
                    //  take string from clip board, combine with existing string and validate.

                    return;
                }
                else
                {
                    // Allowing all other keys when Ctrl is pressed.
                    return;
                }
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                // Allowing Shift key press without any validation.

                return;
            }

            if (IsNavigationOrEraseKey(e))
            {
                // Allowing navigation or erase keys.
                return;
            }

            char keyChar;

            if (IsSignKey(e, out keyChar))
            {
                if (allowSign)
                {
                    if (currentValue.Length == 0)
                    {
                        // Allowing + or - signs as first character.
                        return;
                    }
                }
                else
                {
                    // Not allowing + and - characters.
                    SuppressKey(e);
                    return;
                }
            }

            if (IsIntegerKey(e, out keyChar))
            {
                string keyStr = Convert.ToString(keyChar);

                // Inserting the key at current insertion index of the old integer number.
                string newValue = currentValue.Insert(insertionIndex, keyStr);

                int newInt;
                if (int.TryParse(newValue, out newInt) == false)
                {
                    // Could not convert the new string to integer. Suppressing the key press.
                    SuppressKey(e);

                    return;
                }

                if (GetCharCountExcludingSign(newValue) > maxDigits)
                {
                    SuppressKey(e);

                    return;
                }
            }
            else
            {
                // Suppressing all other keys.
                SuppressKey(e);

                return;
            }
        }

        /// <summary>
        /// Restricts key press for decimal/float fields based on the allowed keys and
        /// given number of digits in whole part and decimal part.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentValue">Current value of the field</param>
        /// <param name="insertionIndex">Index where the new value will get inserted.</param>
        /// <param name="maxWholeDigits">The maximum number of digits allowed in whole part.</param>
        /// <param name="maxDecimalDigits">The maximum number of digits allowed in decimal part.</param>
        public static void RestrictDecimal(ref KeyEventArgs e, string currentValue, int insertionIndex, int maxWholeDigits, int maxDecimalDigits)
        {
            RestrictDecimal(ref e, currentValue, insertionIndex, maxWholeDigits, maxDecimalDigits, false);
        }

        /// <summary>
        /// Restricts key press for decimal/float fields based on the allowed keys and
        /// given number of digits in whole part and decimal part.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="currentValue">Current value of the field</param>
        /// <param name="insertionIndex">Index where the new value will get inserted.</param>
        /// <param name="maxWholeDigits">The maximum number of digits allowed in whole part.</param>
        /// <param name="maxDecimalDigits">The maximum number of digits allowed in decimal part.</param>
        /// <param name="allowSign">If true, allows + and - signs; otherwise will not allow.</param>
        public static void RestrictDecimal(ref KeyEventArgs e, string currentValue, int insertionIndex, int maxWholeDigits, int maxDecimalDigits, bool allowSign)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e", "The KeyEventArgs object passed in is null.");
            }

            if (insertionIndex < 0)
            {
                throw new ArgumentException("The insertionIndex passed in is invalid.", "insertionIndex");
            }

            if (maxWholeDigits < 0)
            {
                throw new ArgumentException("The maxWholeDigits passed in is invalid.", "maxWholeDigits");
            }

            if (maxDecimalDigits < 0)
            {
                throw new ArgumentException("The maxDecimalDigits passed in is invalid.", "maxDecimalDigits");
            }

            if (e.Alt == true)
            {
                // Allowing the key press when Alt is pressed.
                return;
            }

            if (e.Control == true)
            {
                if (e.KeyCode == Keys.V)
                {
                    // Not allowing paste operation (Ctrl+v), as the current validation does not take care of this.
                    SuppressKey(e);

                    // To Do: instead of suppressing paste,
                    //  take string from clip board, combine with existing string and validate.

                    return;
                }
                else
                {
                    // Allowing all other keys when Ctrl is pressed.
                    return;
                }
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                // Allowing Shift key press without any validation.

                return;
            }

            if (IsNavigationOrEraseKey(e))
            {
                // Allowing navigation or erase keys.
                return;
            }

            if (IsDecimalPointKey(e))
            {
                if (currentValue.Contains("."))
                {
                    // Already one . is available. Suppressing next one.
                    SuppressKey(e);

                    return;
                }
                else
                {
                    // Allowing first . without any validation.
                    return;
                }
            }

            char keyChar;

            if (IsSignKey(e, out keyChar))
            {
                if (allowSign)
                {
                    if (currentValue.Length == 0)
                    {
                        // Allowing + or - signs as first character.
                        return;
                    }
                }
                else
                {
                    // Not allowing + and - characters.
                    SuppressKey(e);
                    return;
                }
            }

            if (IsIntegerKey(e, out keyChar))
            {
                string keyStr = Convert.ToString(keyChar);

                // Inserting the key at current insertion index of the old decimal number.
                string newValue = currentValue.Insert(insertionIndex, keyStr);

                decimal newDecimal;
                if (decimal.TryParse(newValue, out newDecimal) == false)
                {
                    // Could not convert the new string to decimal. Suppressing the key press.
                    SuppressKey(e);

                    return;
                }

                // Verifying length of whole part and decimal part.
                int wholeDigitCount;
                int decimalDigitCount;

                if (GetDecimaNumberPartCounts(newValue, out wholeDigitCount, out decimalDigitCount))
                {
                    if (wholeDigitCount > maxWholeDigits)
                    {
                        SuppressKey(e);

                        return;
                    }

                    if (decimalDigitCount > maxDecimalDigits)
                    {
                        SuppressKey(e);

                        return;
                    }
                }
                else
                {
                    // Error splitting the new value to whole part and decimal part. Suppressing the key press.
                    SuppressKey(e);

                    return;
                }

            }
            else
            {
                // Suppressing all other keys.
                SuppressKey(e);

                return;
            }
        }

        #endregion Public Members

        #region Private Members

        /// <summary>
        /// Checks the given key could be part of an integer or not.
        /// If returned true, the out parameter (inputChar) will contain the corresponding charecter user typed in.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="inputChar"></param>
        /// <returns></returns>
        private static bool IsIntegerKey(KeyEventArgs e, out char inputChar)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    {
                        if (e.Shift == false)
                        {
                            inputChar = (char)e.KeyValue;
                            return true;
                        }
                        else
                        {
                            inputChar = '!';
                            return false;
                        }
                    }
                case Keys.NumPad0:
                    {
                        inputChar = '0';
                        return true;
                    }
                case Keys.NumPad1:
                    {
                        inputChar = '1';
                        return true;
                    }
                case Keys.NumPad2:
                    {
                        inputChar = '2';
                        return true;
                    }
                case Keys.NumPad3:
                    {
                        inputChar = '3';
                        return true;
                    }
                case Keys.NumPad4:
                    {
                        inputChar = '4';
                        return true;
                    }
                case Keys.NumPad5:
                    {
                        inputChar = '5';
                        return true;
                    }
                case Keys.NumPad6:
                    {
                        inputChar = '6';
                        return true;
                    }
                case Keys.NumPad7:
                    {
                        inputChar = '7';
                        return true;
                    }
                case Keys.NumPad8:
                    {
                        inputChar = '8';
                        return true;
                    }
                case Keys.NumPad9:
                    {
                        inputChar = '9';
                        return true;
                    }
            }

            if (IsSignKey(e, out inputChar))
            {
                return true;
            }
            else
            {
                // The key should not be part of an integer. Assigning a dummy value to out parameter and returning false.
                inputChar = '!';
                return false;
            }
        }

        /// <summary>
        /// Checks if the given key corresponds to + or - signs.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="signKey"></param>
        /// <returns>Returns true if the given key is either + or -. If return value is true, the out parameter can be used.</returns>
        private static bool IsSignKey(KeyEventArgs e, out char signKey)
        {
            switch (e.KeyCode)
            {
                // + sign on numeric key pad
                case Keys.Add:
                    {
                        signKey = '+';
                        return true;
                    }
                // + sign on row just below function keys
                case Keys.Oemplus:
                    {
                        // Checking Shift key press as same KeyCode is used for both + and =
                        if (e.Shift)
                        {
                            signKey = '+';
                            return true;
                        }
                        else
                        {
                            signKey = '!';
                            return false;
                        }
                    }
                // - sign on numeric key pad
                case Keys.Subtract:
                    {
                        signKey = '-';
                        return true;
                    }
                // - sign on row just below function keys
                case Keys.OemMinus:
                    {
                        // Checking Shift key press as same KeyCode is used for both - and _
                        if (e.Shift == false)
                        {
                            signKey = '-';
                            return true;
                        }
                        else
                        {
                            signKey = '!';
                            return false;
                        }
                    }
                default:
                    {
                        signKey = '!';
                        return false;
                    }
            }
        }

        /// <summary>
        /// Checks if the given key is a navigation key or erase key.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static bool IsNavigationOrEraseKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back ||
               e.KeyCode == Keys.Delete ||
               e.KeyCode == Keys.End ||
               e.KeyCode == Keys.Home ||
               e.KeyCode == Keys.Right ||
               e.KeyCode == Keys.Left ||
               e.KeyCode == Keys.Up ||
               e.KeyCode == Keys.Down ||
               e.KeyCode == Keys.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the given key corresponds to a decimal point or not.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static bool IsDecimalPointKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemPeriod ||
               e.KeyCode == Keys.Decimal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Splits the given decimal string into whole part and decimal part and returns their counts.
        /// If return value is true the out parameters will contain the corresponding digit counts.
        /// </summary>
        /// <param name="decimalNumber">String representation of the decimal number.</param>
        /// <param name="wholeDigitCount">Count of digits in whole part</param>
        /// <param name="decimalDigitCount">Count of digits in decimal part</param>
        /// <returns></returns>
        private static bool GetDecimaNumberPartCounts(string decimalNumber, out int wholeDigitCount, out int decimalDigitCount)
        {
            wholeDigitCount = 0;
            decimalDigitCount = 0;

            string[] decimalSplit = decimalNumber.Split('.');

            if (decimalSplit.Length > 2)
            {
                // More than one decimal points (.)in the string.
                return false;
            }

            if (decimalSplit.Length > 0)
            {
                wholeDigitCount = GetCharCountExcludingSign(decimalSplit[0]);
            }

            if (decimalSplit.Length > 1)
            {
                decimalDigitCount = GetCharCountExcludingSign(decimalSplit[1]);
            }

            return true;
        }

        /// <summary>
        /// Gives a beep sound and supresses the key.
        /// </summary>
        /// <param name="e"></param>
        private static void SuppressKey(KeyEventArgs e)
        {
            //To Do: make the beep sound similar to windows default sound.
            Console.Beep(250, 20);

            e.SuppressKeyPress = true;
        }

        /// <summary>
        /// Returns the count of characters in the given string, excluding + and - signs.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int GetCharCountExcludingSign(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            if (value.Contains("+"))
            {
                value = value.Replace("+", "");
            }

            if (value.Contains("-"))
            {
                value = value.Replace("-", "");
            }

            return value.Length;
        }

        #endregion Private Members


        public static void RestrictDecimal(ref KeyEventArgs e, string currentValue)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e", "The KeyEventArgs object passed in is null.");
            }



            if (e.Alt == true)
            {
                // Allowing the key press when Alt is pressed.
                return;
            }

            if (e.Control == true)
            {
                if (e.KeyCode == Keys.V)
                {
                    // Not allowing paste operation (Ctrl+v), as the current validation does not take care of this.
                    SuppressKey(e);

                    // To Do: instead of suppressing paste,
                    //  take string from clip board, combine with existing string and validate.

                    return;
                }
                else
                {
                    // Allowing all other keys when Ctrl is pressed.
                    return;
                }
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                // Allowing Shift key press without any validation.

                return;
            }

            if (IsNavigationOrEraseKey(e))
            {
                // Allowing navigation or erase keys.
                return;
            }



            char keyChar;

            if (IsArithMeticOpetationKey(e, out keyChar))
            {
                IsCheckDecimalPoint(e, currentValue);




                string keyStr = Convert.ToString(keyChar);

                // Inserting the key at current insertion index of the old decimal number.
                // string newValue = currentValue.Insert(insertionIndex, keyStr);
                if (currentValue != "")
                {
                    string lastChar = currentValue.Substring(currentValue.Length - 1);

                    if (keyStr != "(")
                    {
                        if (lastChar != ")")
                        {
                            int newInt, newInt2;

                            if (int.TryParse(keyStr, out newInt) == false)
                            {
                                if (int.TryParse(lastChar, out newInt2) == false)
                                {
                                    // Could not convert the new string to decimal. Suppressing the key press.
                                    SuppressKey(e);

                                    return;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }

                }
            }
            else if (IsIntegerKeyWithOperation(e, out keyChar))
            {
                return;
            }

            else
            {
                // Suppressing all other keys.
                SuppressKey(e);

                return;
            }
        }
        private static void IsCheckDecimalPoint(KeyEventArgs e, string currentValue)
        {
            string number = "";
            if (e.KeyCode == Keys.OemPeriod ||
               e.KeyCode == Keys.Decimal)
            {

                int i = 1;

                while (currentValue.Length >= i)
                {

                    number = currentValue.Substring(currentValue.Length - i);
                    decimal newDecimal;

                    if (decimal.TryParse(number, out newDecimal) == true)
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (number.Contains("."))
                {
                    //    // Already one . is available.Suppressing next one.
                    SuppressKey(e);


                }

            }

        }
        private static bool IsArithMeticOpetationKey(KeyEventArgs e, out char signKey)
        {
            switch (e.KeyCode)
            {
                // + sign on numeric key pad
                case Keys.Add:
                    {
                        signKey = '+';
                        return true;
                    }
                // + sign on row just below function keys
                case Keys.Oemplus:
                    {
                        // Checking Shift key press as same KeyCode is used for both + and =
                        if (e.Shift)
                        {
                            signKey = '+';
                            return true;
                        }
                        else
                        {
                            signKey = '!';
                            return false;
                        }
                    }
                // - sign on numeric key pad
                case Keys.Subtract:
                    {
                        signKey = '-';
                        return true;
                    }

                case Keys.Multiply:
                    {
                        signKey = '*';
                        return true;
                    }
                case Keys.Divide:
                    {
                        signKey = '/';
                        return true;
                    }
                // - sign on row just below function keys
                case Keys.OemMinus:
                    {
                        // Checking Shift key press as same KeyCode is used for both - and _
                        if (e.Shift == false)
                        {
                            signKey = '-';
                            return true;
                        }
                        else
                        {
                            signKey = '!';
                            return false;
                        }
                    }
                case Keys.D5:
                    {
                        if (e.Shift == false)
                        {
                            signKey = '5';
                            return true;
                        }
                        else
                        {
                            signKey = '%';
                            return true;
                        }
                    }
                case Keys.D8:
                    {
                        if (e.Shift == false)
                        {
                            signKey = '8';
                            return true;
                        }
                        else
                        {
                            signKey = '*';
                            return true;
                        }
                    }
                case Keys.D9:
                    {
                        if (e.Shift == false)
                        {
                            signKey = '9';
                            return true;
                        }
                        else
                        {
                            signKey = '(';
                            return true;
                        }
                    }
                case Keys.D0:
                    {
                        if (e.Shift == false)
                        {
                            signKey = '0';
                            return true;
                        }
                        else
                        {
                            signKey = ')';
                            return true;
                        }
                    }

                case Keys.OemQuestion:
                    {
                        if (e.Shift == false)
                        {
                            signKey = '/';
                            return true;
                        }
                        else
                        {
                            signKey = '!';
                            return false;
                        }
                    }
                case Keys.OemPeriod:
                    {

                        signKey = '.';
                        return true;
                    }

                case Keys.Decimal:
                    {

                        signKey = '.';
                        return true;
                    }


                default:
                    {
                        signKey = '!';
                        return false;
                    }

            }
        }
        private static bool IsIntegerKeyWithOperation(KeyEventArgs e, out char inputChar)
        {
            switch (e.KeyCode)
            {

                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D6:
                case Keys.D7:
                    {
                        if (e.Shift == false)
                        {
                            inputChar = (char)e.KeyValue;
                            return true;
                        }
                        else
                        {
                            inputChar = '!';
                            return false;
                        }
                    }
                case Keys.D0:
                case Keys.D5:
                case Keys.D8:
                case Keys.D9:

                case Keys.NumPad0:
                    {
                        inputChar = '0';
                        return true;
                    }
                case Keys.NumPad1:
                    {
                        inputChar = '1';
                        return true;
                    }
                case Keys.NumPad2:
                    {
                        inputChar = '2';
                        return true;
                    }
                case Keys.NumPad3:
                    {
                        inputChar = '3';
                        return true;
                    }
                case Keys.NumPad4:
                    {
                        inputChar = '4';
                        return true;
                    }
                case Keys.NumPad5:
                    {
                        inputChar = '5';
                        return true;
                    }
                case Keys.NumPad6:
                    {
                        inputChar = '6';
                        return true;
                    }
                case Keys.NumPad7:
                    {
                        inputChar = '7';
                        return true;
                    }
                case Keys.NumPad8:
                    {
                        inputChar = '8';
                        return true;
                    }
                case Keys.NumPad9:
                    {
                        inputChar = '9';
                        return true;
                    }
            }

            if (IsArithMeticOpetationKey(e, out inputChar))
            {
                return true;
            }
            else
            {
                // The key should not be part of an integer. Assigning a dummy value to out parameter and returning false.
                inputChar = '!';
                return false;
            }
        }
    }
}
