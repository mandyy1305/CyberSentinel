using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PasswordStrengthMeter : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI textInput;
    public TextMeshProUGUI textStrength;
    public static event Action<int> OnPasswordStrengthChanged;
    int score = 0;
    int CalculateStrengthScore()
    {
        string password = textInput.text;
        int _score = 0;

        // Length score
        if (password.Length >= 8)
            _score += 20;

        // Lowercase letters
        if (Regex.IsMatch(password, @"[a-z]"))
            _score += 20;

        // Uppercase letters
        if (Regex.IsMatch(password, @"[A-Z]"))
            _score += 20;

        // Numbers
        if (Regex.IsMatch(password, @"[0-9]"))
            _score += 20;

        // Special characters
        if (Regex.IsMatch(password, @"[!@#$%^&*(),.?:{ }|<>]"))
            _score += 20;

        // Deduct points for common patterns
        if (Regex.IsMatch(password, @"^(1234|password|qwerty|abc123)$"))
            _score -= 40;

        Debug.Log(_score);
        return _score;
    }
    private Color GetColorBasedOnStrength(int score)
    {
        if (score <= 60)
            return Color.red;
        else if (score <= 80)
            return Color.yellow;
        else
            return Color.green;
    }

    private string GetFeedbackText(int score)
    {
        if (score <= 60)
            return "Weak";
        else if (score <= 80)
            return "Medium";
        else
            return "Strong";
    }
    public void PasswordStrength()
    {
        score = CalculateStrengthScore();
        textStrength.color = GetColorBasedOnStrength(score);
        textStrength.text = GetFeedbackText(score);
    }

    public void SendStrengthScore()
    {
        OnPasswordStrengthChanged?.Invoke(score);
        panel.transform.GetChild(0).gameObject.SetActive(false);
    }
}
