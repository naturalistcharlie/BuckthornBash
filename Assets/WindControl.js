#pragma strict

// WindControl

function Start() {
    WindUpdate();
}

function WindUpdate() {
    Wind.winddirection = Random.insideUnitSphere * 10;
    Wind.winddirection.y = 0;

    Invoke("WindUpdate", 3);
}