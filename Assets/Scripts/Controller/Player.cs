using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MagicCricle_Isaac
{
    public class Player : BaseController
    {
        Image imageSpellingBar;
        public Animator animator;
        public int SkillIndex;
        Transform skillsUIPanel;
        float _hp;
        float _hpMax;
        Image _imageHp;
        float _mp;
        float _mpMax;
        Image _imageMp;
        float _movingSpeed;
        Transform _portal;
        public Transform Portal
        {
            get { return _portal; }
            set { _portal = value; }
        }
        // Start is called before the first frame update
        void Start()
        {
            SkillIndex = 0;
            skillsUIPanel = GameObject.Find("SkillsUIPanel").transform;
            _hp = _hpMax = 100f;
            _mp = _mpMax = 100f;
            SkillIndex = 0;
            _movingSpeed = 1;
            _imageHp = transform.Find("PlayerCanvas").Find("Hp").GetComponent<Image>();
            _imageMp = transform.Find("PlayerCanvas").Find("Mp").GetComponent<Image>();
            imageSpellingBar = transform.Find("PlayerCanvas").Find("SpellingBar").GetComponent<Image>();
            imageSpellingBar.fillAmount = 0;
            _portal = null;

            SwitchSkillInList(0);
        }

        // Update is called once per frame
        void Update()
        {
            MpIncreaseByTime();
            Run();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine("Spelling");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchSkillInList(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchSkillInList(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchSkillInList(2);
            if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchSkillInList(3);

        }

        void MpIncreaseByTime()
        {
            _mp = _mp + Time.deltaTime * 5 > _mpMax ? _mpMax : _mp + Time.deltaTime * 5;
            _imageMp.fillAmount = _mp / _mpMax;
        }

        void SwitchSkillInList(int index)
        {
            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();
            if (index >= availableSkillsModel.Count)
            {
                Debug.Log("index >= availableSkillsModel.Count");
                return;
            }
            if (index == SkillIndex)
            {
                Debug.Log("index == SkillIndex");
                return;
            }
            SkillView preSkillView = skillsUIPanel.GetChild(SkillIndex).GetChild(0).GetComponent<SkillView>();
            SkillView targetSkillView = skillsUIPanel.GetChild(index).GetChild(0).GetComponent<SkillView>();

            preSkillView.SetFocus(false);
            targetSkillView.SetFocus(true);

            SkillIndex = index;
        }

        void Run()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            transform.position = transform.position + movement * _movingSpeed * Time.deltaTime;
        }

        IEnumerator Spelling()
        {
            _movingSpeed = 0.5f;

            AvailableSkillsModel availableSkillsModel = this.GetModel<AvailableSkillsModel>();
            SkillView skillView = skillsUIPanel.GetChild(SkillIndex).GetChild(0).GetComponent<SkillView>();
            if (!skillView.IsReady || _mp < skillView.MpCost)
            {
                imageSpellingBar.fillAmount = 0;
                _movingSpeed = 1;
                StopCoroutine("Spelling");
                yield return 0;
            }
            MagicCricleData data = skillView.Data;

            this.SendCommand(new ShowMagicCricleEffectCommand(transform.Find("MagicCricleEffect"), data));

            float value = 0;

            while (imageSpellingBar.fillAmount < 1)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    imageSpellingBar.fillAmount = 0;
                    Destroy(transform.Find("MagicCricleEffect").GetChild(0).gameObject);
                    _movingSpeed = 1;
                    StopCoroutine("Spelling");
                    yield return 0;
                }
                // Debug.Log($"value : {value}");
                value += Time.deltaTime;
                imageSpellingBar.fillAmount = value / skillView.SpellingTime;
                yield return 0;
            }
            imageSpellingBar.fillAmount = 0;
            _movingSpeed = 1;
            Destroy(transform.Find("MagicCricleEffect").GetChild(0).gameObject);
            SkillRelease(skillView);
        }

        void SkillRelease(SkillView skillView)
        {
            _mp -= skillView.MpCost;
            _imageMp.fillAmount = _mp / _mpMax;
            skillView.StartRelease(transform);
        }

        public void DecreaseHp(float value)
        {
            _hp = _hp - value < 0 ? 0 : _hp - value;
            _imageHp.fillAmount = _hp / _hpMax;
        }

        public void IncreaseHp(float value)
        {
            _hp = _hp + value > _hpMax ? _hpMax : _hp + value;
            _imageHp.fillAmount = _hp / _hpMax;
        }

        public void DecreaseMp(float value)
        {
            _mp = _mp - value < 0 ? 0 : _mp - value;
            _imageMp.fillAmount = _mp / _mpMax;
        }

        public void IncreaseMp(float value)
        {
            _mp = _mp + value > _mpMax ? _mpMax : _mp + value;
            _imageMp.fillAmount = _mp / _mpMax;
        }
    }
}
