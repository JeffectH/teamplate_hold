using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bootstrap _bootstrap;
    [SerializeField] private UploadingTexts _uploadingTexts;
    [SerializeField] private GestureMove _gestureMove;
    [SerializeField] private TimerHold _timerHold;
    [Space]
    [SerializeField] private TypewriterEffect _task0;
    [SerializeField] private TypewriterEffect _task1;
    [SerializeField] private TypewriterEffect _win;
    [Space]
    [SerializeField] private Image _gestureTarget;
    [SerializeField] private Animator _canvasGroup;
    [SerializeField] private Animator _animatorArrow;
    [SerializeField] private Animator _animatorTextGesture;
    [SerializeField] private Animator _animatorSlider;
    [SerializeField] private Animator _like;
    [SerializeField] private Animator _repeatBtn;
    [Space]
    [SerializeField] private SoundManger _soundManger;

    private bool _isGestureReachTarget;

    private void OnEnable()
    {
        _bootstrap.DownloadComplete += StartGame;
        _gestureMove.BeginDrag += BeginDragGesture;
        _gestureMove.HitTarget += HideArrow;
        _gestureMove.HitTarget += PerformingActionsGestureReachTarget;
        _gestureMove.ReturnOnDefaultPos += ShowArrow;
        _timerHold.OnTimerEnd += PerformingActionsHoldComplete;
    }

    private void OnDisable()
    {
        _bootstrap.DownloadComplete -= StartGame;
        _gestureMove.BeginDrag -= BeginDragGesture;
        _gestureMove.HitTarget -= HideArrow;
        _gestureMove.HitTarget -= PerformingActionsGestureReachTarget;
        _gestureMove.ReturnOnDefaultPos -= ShowArrow;
        _timerHold.OnTimerEnd -= PerformingActionsHoldComplete;
    }

    private void StartGame()
    {
        _canvasGroup.SetTrigger("Show");
        _task0.StartEffect(_uploadingTexts.TextTask0);
    }

    private void BeginDragGesture()
    {
        _animatorTextGesture.SetTrigger("Hide");
        _soundManger.SoundStart.Play();
    }

    private void PerformingActionsGestureReachTarget()
    {
        if (_isGestureReachTarget == false)//костыль
        {
            _animatorSlider.SetBool("IsShow", true);
            _animatorSlider.SetBool("IsHide", false);

            _task0.GetComponent<Animator>().SetTrigger("Hide");
            _task1.StartEffect(_uploadingTexts.TextTask1);
            _gestureTarget.enabled = false;
            _isGestureReachTarget = true;

            _soundManger.SoundTarget.Play();
        }
    }

    private void HideArrow()
    {
        _animatorArrow.SetBool("IsHide", true);
        _animatorArrow.SetBool("IsShow", false);
    }

    private void ShowArrow()
    {
        _animatorArrow.SetBool("IsHide", false);
        _animatorArrow.SetBool("IsShow", true);
    }

    private void PerformingActionsHoldComplete()
    {
        _soundManger.SoundWin.Play();
        _soundManger.SoundRegular.Stop();

        _animatorSlider.SetBool("IsShow", false);
        _animatorSlider.SetBool("IsHide", true);

        _task1.GetComponent<Animator>().SetTrigger("Hide");

        _win.StartEffect(_uploadingTexts.TextWin);

        _gestureMove.gameObject.SetActive(false);

        StartCoroutine(LikeAnimation());
    }

    private IEnumerator LikeAnimation()
    {
        _like.SetTrigger("Show");
        yield return new WaitForSeconds(0.2f);
        _soundManger.SoundLike.Play();
        yield return new WaitForSeconds(0.4f);
        _soundManger.SoundLike.Play();
        yield return new WaitForSeconds(0.6f);
        _soundManger.SoundLike.Play();

        yield return new WaitForSeconds(1.0f);

        _repeatBtn.gameObject.SetActive(true);
        _repeatBtn.SetTrigger("Show");
    }
}
