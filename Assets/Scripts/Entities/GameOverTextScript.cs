using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameOverTextScript : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private TMP_Text textField;

    [Header("Settings")]
    [TextArea(2, 6)]
    [SerializeField] private string fullText = "GameOver";
    [SerializeField] private float charactersPerSecond = 30f;
    [SerializeField] private bool playOnStart = true;
    [SerializeField] private bool useUnscaledTime = false;

    [Header("Optional Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip typeSound;

    [Header("Events")]
    public UnityEvent onTypingStarted;
    public UnityEvent onTypingFinished;

    private Coroutine typingRoutine;

    public bool IsTyping => typingRoutine != null;

    private void Awake()
    {
        if (textField == null)
            textField = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (playOnStart)
            Play(fullText);
    }

    /// <summary>Starts typing the given string from the beginning.</summary>
    public void Play(string text)
    {
        Stop();
        fullText = text;
        typingRoutine = StartCoroutine(TypeRoutine());
    }

    /// <summary>Stops typing and leaves the current text as is.</summary>
    public void Stop()
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
            typingRoutine = null;
        }
    }

    /// <summary>Immediately shows the full text.</summary>
    public void Skip()
    {
        if (!IsTyping) return;

        Stop();
        textField.maxVisibleCharacters = int.MaxValue;
        onTypingFinished?.Invoke();
    }

    private IEnumerator TypeRoutine()
    {
        onTypingStarted?.Invoke();

        // Set the whole string up front; TMP handles layout and rich text tags,
        // and we just reveal characters progressively.
        textField.text = fullText;
        textField.maxVisibleCharacters = 0;

        // Force mesh update so textInfo.characterCount is accurate.
        textField.ForceMeshUpdate();
        int totalCharacters = textField.textInfo.characterCount;

        float delay = 1f / Mathf.Max(0.01f, charactersPerSecond);
        int visible = 0;

        while (visible < totalCharacters)
        {
            visible++;
            textField.maxVisibleCharacters = visible;

            if (audioSource != null && typeSound != null)
                audioSource.PlayOneShot(typeSound);

            if (useUnscaledTime)
                yield return new WaitForSecondsRealtime(delay);
            else
                yield return new WaitForSeconds(delay);
        }

        typingRoutine = null;
        onTypingFinished?.Invoke();
    }
}