using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private StageData   stageData;
    [SerializeField]
    private KeyCode     keyCodeAttack = KeyCode.Space;

    private Movement2D  movement2D;
    private Weapon      weapon;

    private int distance;
    public  int Distance {
        set => distance = Mathf.Max(0, value);
        get => distance;
    }

    private void Awake() {
        movement2D  = GetComponent<Movement2D>();
        weapon      = GetComponent<Weapon>();
    }

    private void Update() {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.MoveTo(new Vector3(x, 0, 0));

        if (Input.GetKeyDown(keyCodeAttack)) {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack)) {
            weapon.StopFiring();
        }
    }

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
