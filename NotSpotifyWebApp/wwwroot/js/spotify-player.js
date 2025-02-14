"use-strict"

let player;
let accessToken;

const defaultVolume = 0.5;

async function getAccessToken() {
    try {
        const response = await fetch(`/api/token`);
        const data = await response.json();
        accessToken = data.token;
        return accessToken;
    }
    catch (error) {
        console.error(`Error fetching the access token: ${error}`);
    }
}

async function initialisePlayer() {
    if (window.spotifyPlayer) {
        console.log("Spotify Player already initialized.");
        return;
    }

    window.onSpotifyWebPlaybackSDKReady = async () => {
        accessToken = await getAccessToken();

        player = new Spotify.Player({
            name: `Dami's Spotify Application'`,
            getOAuthToken: cb => { cb(accessToken); },
            volume: defaultVolume
        })

        player.addListener('ready', ({ device_id }) => {
            transferPlaybackHere(device_id);
        });

        player.connect();
    }
}

async function transferPlaybackHere(device_id) {
    try {
        await fetch('https://api.spotify.com/v1/me/player', {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${accessToken}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                device_ids: [device_id],
                play: true
            })
        });
    } catch (error) {
        console.error("Failed to transfer playback: ", error);
    }
}

async function playTrack(trackUri) {
    try {
        await fetch('https://api.spotify.com/v1/me/player/play', {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${accessToken}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                uris: [trackUri]
            })
        });
        console.log("Track is playing!");
    } catch (error) {
        console.error("Failed to play track:", error);
    }
}

document.addEventListener("DOMContentLoaded", function () {
    initialisePlayer();

    /*
    document.querySelectorAll(".play-button.play").forEach(button => {
        button.addEventListener("click", function () {
            const trackId = this.getAttribute("data-track-id");
            if (trackId) {
                playTrack(`spotify:track:${trackId}`);
            }
        })
    })
    */
});