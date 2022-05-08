using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class SkillView : BaseController
    {
        MagicCricleData _data;
        public MagicCricleData Data
        {
            get { return _data; }
            set
            {
                _data = value;
                InitSkill();
            }
        }
        float _spellingTime;
        public float SpellingTime
        {
            get { return _spellingTime; }
        }
        public bool IsReady;
        Image _imageCD;
        float _CDTime;
        HashSet<string> _skillReleaseHashSet;
        public float MpCost
        {
            get { return _mpCost; }
        }
        float _mpCost;
        float _bulletSpeed;
        void Start()
        {
            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();

            _imageCD = transform.Find("CDImage").GetComponent<Image>();
            _imageCD.fillAmount = 0;
            IsReady = true;
            _skillReleaseHashSet = new HashSet<string>();

            transform.Find("RightPanel").Find("ClearButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log("ClearButton");
                availableSkillsModel.SkillsList[transform.parent.GetSiblingIndex()] = default(MagicCricleData);
                Destroy(gameObject);
                availableSkillsModel.Count.Value--;
            });
        }

        public void StartRelease(Transform targetTrans)
        {
            StartCD();
            Animator animator = targetTrans.GetComponent<Player>().animator;
            float h = animator.GetFloat("Horizontal");
            float v = animator.GetFloat("Vertical");

            switch (_data.ElementArr[0])
            {
                case UnitStyle.GROUND:
                    break;
                case UnitStyle.THUNDER:
                    _bulletSpeed += 2f;
                    break;
                case UnitStyle.WATER:
                    targetTrans.GetComponent<Player>().IncreaseMp(50);
                    break;
                case UnitStyle.PLANT:
                    break;
                case UnitStyle.MOUNTAIN:
                    break;
                case UnitStyle.FIRE:
                    break;
                case UnitStyle.WIND:
                    break;
                case UnitStyle.LIGHT:
                    break;
                default:
                    break;
            }
            this.SendCommand(new ShootMagicBulletCommand(targetTrans, h, v, 3, _bulletSpeed));
        }

        void StartCD()
        {
            IsReady = false;
            _imageCD.fillAmount = 1;
            StartCoroutine("ShowingCDView");
        }

        IEnumerator ShowingCDView()
        {
            float value = _CDTime;
            while (_imageCD.fillAmount > 0)
            {
                // Debug.Log($"value : {value}");
                value -= Time.deltaTime;
                _imageCD.fillAmount = value / _CDTime;
                yield return 0;
            }

            IsReady = true;
        }

        public void SetFocus(bool value)
        {
            if (transform.Find("FocusImage") == null)
            {
                Debug.Log("FocusImageTrans == null");
            }
            if (transform.Find("FocusImage").gameObject == null)
            {
                Debug.Log("FocusImageTrans.gameObject == null");
            }
            transform.Find("FocusImage").gameObject.SetActive(value);
        }

        void InitSkill()
        {
            _CDTime = 5f;
            _mpCost = 5 * 3 + (_data.StarArr_1.Length + _data.StarArr_2.Length) * 5;
            _spellingTime = 3f;
            _bulletSpeed = 3f;
            for (int i = 0; i < _data.StarArr_1.Length; i++)
            {
                if (_data.StarArr_1[i] == UnitStyle.DecreaseCD)
                {
                    float value = 5f - 1f;
                    if (_data.StarArr_1[(i + 1) % _data.StarArr_1.Length] == UnitStyle.IncreaseEffect) value -= 1f;
                    if (_data.StarArr_1[(i - 1) < 0 ? _data.StarArr_1.Length - 1 : (i - 1)] == UnitStyle.IncreaseEffect) value -= 1f;
                    _CDTime = _CDTime > value ? value : _CDTime;
                }

                if (_data.StarArr_1[i] == UnitStyle.DecreaseSpellingTime)
                {
                    float value = 3f - 0.5f;
                    if (_data.StarArr_1[(i + 1) % _data.StarArr_1.Length] == UnitStyle.IncreaseEffect) value -= 0.5f;
                    if (_data.StarArr_1[(i - 1) < 0 ? _data.StarArr_1.Length - 1 : (i - 1)] == UnitStyle.IncreaseEffect) value -= 0.5f;
                    _spellingTime = _spellingTime > value ? value : _spellingTime;
                }
            }
        }
    }
}