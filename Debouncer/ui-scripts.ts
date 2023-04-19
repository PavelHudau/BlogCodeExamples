export class CancellationToken {
    #isCancelled: boolean;

    public get isCancelled() { return this.#isCancelled };

    public cancel(): void {
        this.#isCancelled = true;
    }
}

export class Debouncer {
    readonly #maxDelayMs: number;
    readonly #minDelayMs: number;
    readonly #delayNoise: number;
    #latestToken: CancellationToken = new CancellationToken();
    #latestDebounceTimeMs: number;

    constructor(maxDelayMs: number = 1000, minDelayMs: number = 0, delayNoise: number = 35) {
        // Make sure #maxDelayMs is greater than 0;
        this.#maxDelayMs = Math.max(maxDelayMs, 0);
        // Make sure #minDelayMs is greater than 0 and less or equal to #maxDelayMs;
        this.#minDelayMs = Math.min(Math.max(minDelayMs, 0), this.#maxDelayMs);
        // #delayNoise must be less or equal to #maxDelayMs,
        // otherwise all delays will be considered as noise and will be ignored.
        this.#delayNoise = Math.min(delayNoise, this.#maxDelayMs);
    }

    public async debounce() {
        this.#latestToken.cancel();
        const currentToken = new CancellationToken();
        this.#latestToken = currentToken;
        const delayByMs = this.#nextDelayMs();
        if(delayByMs > 0 && delayByMs >= this.#delayNoise) {
            await delay(delayByMs);
        }

        Promise.resolve(currentToken);
    }

    get #nowTimeInMs(): number {
        return new Date().getTime();
    }

    #nextDelayMs(): number {
        const nowTimeInMs = this.#nowTimeInMs;
        const delta = nowTimeInMs - this.#latestDebounceTimeMs;
        this.#latestDebounceTimeMs = nowTimeInMs;
        const scale = 270000000;
        let delayMs = Math.floor(delta > 0 ? (scale / Math.pow(delta, 1.9)) : this.#maxDelayMs);
        delayMs = Math.min(delayMs, this.#maxDelayMs);
        return Math.max(delayMs, this.#minDelayMs);
    }
 }

async function delay(delayByMs: number) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(true);
        }, delayByMs);
    });
}

