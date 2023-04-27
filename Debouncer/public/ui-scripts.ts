import { DeBouncer, CancellationToken } from "./debouncer";

export async function onProductTileClickNaive(eventArgs) {
    showLoading();
    const product = await fetchProduct(eventArgs.productId);
    hideLoading();
    showSlideOutProductPanel(product);
}

let productFetchCancellationToken = new CancellationToken();

export async function onProductTileClickWithCancellation(eventArgs) {
    // Cancel previously created token.
    productFetchCancellationToken.cancel();

    // Create and keep current token.
    const currentToken = new CancellationToken();
    productFetchCancellationToken = currentToken;

    const product = await fetchProduct(eventArgs.productId);

    // If current token was cancelled by next Product Tile click, then
    // just exit.
    if (currentToken.isCancelled) {
        return;
    }

    // Fetch was not cancelled, so we can show Product in
    // the slide out panel.
    showSlideOutProductPanel(product);
}

async function delayByMs(delayByMs: number) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(true);
        }, delayByMs);
    });
}

export async function onProductTileClickWithCancellationAndDelay(eventArgs) {
    productFetchCancellationToken.cancel();


    const currentToken = new CancellationToken();
    productFetchCancellationToken = currentToken;

    // Delay real service call by 1 second
    await delayByMs(1000);

    // If new click happened before delay expired, then just exit.
    if (currentToken.isCancelled) {
        return;
    }

    const product = await fetchProduct(eventArgs.productId);

    if (currentToken.isCancelled) {
        return;
    }

    showSlideOutProductPanel(product);
}

const maxDelayMs = 3000; // 3 seconds
const minDelayMs = 0;
// We need to remember time of last click to be able
// to calculate frequency.
let latestDebounceTimeMs = new Date().getTime();

function nextDelayMs(): number {
    const nowTimeInMs = new Date().getTime();
    // Frequency is a difference in milliseconds between
    // subsequent clicks.
    const frequency = nowTimeInMs - latestDebounceTimeMs;
    latestDebounceTimeMs = nowTimeInMs;

    const P0 = 2;
    const k = -2.5;
    let delayMs = Math.floor(P0 * Math.pow(Math.E, k * frequency));

    // Ensure delayMs is within the boundaries between
    // minDelayMs and maxDelayMs.
    delayMs = Math.min(delayMs, maxDelayMs);
    return Math.max(delayMs, minDelayMs);
}

export async function onProductTileClickWithCancellationAndExponentialDelay(eventArgs) {
    productFetchCancellationToken.cancel();

    const currentToken = new CancellationToken();
    productFetchCancellationToken = currentToken;

    // It does not make sense to delay for very short period of time.
    // We settled on 40 ms empirically.
    const ignoreDelayLessThanMs = 40;
    const delayMs = nextDelayMs();
    if (delayMs > ignoreDelayLessThanMs) {
        await delayByMs(delayMs);
    }

    if (currentToken.isCancelled) {
        return;
    }

    const product = await fetchProduct(eventArgs.productId);

    if (currentToken.isCancelled) {
        return;
    }

    showSlideOutProductPanel(product);
}

// Create a DeBouncer instance for each user action 
// ou would like to  De-Bounce.
const productTileClickDeBouncer = new DeBouncer();

export async function onProductTileClickWithDebBouncer(eventArgs) {
    const currentToken = await productTileClickDeBouncer.debounce();

    if (currentToken.isCancelled) {
        return;
    }

    const product = await fetchProduct(eventArgs.productId);

    if (currentToken.isCancelled) {
        return;
    }

    showSlideOutProductPanel(product);
}

interface Product {
}

function showLoading() {
    // Disables all click event handlers.
}

function hideLoading() {
    // Disables all click event handlers.
}

function showSlideOutProductPanel(product) {
    // Shows product data.
}

async function fetchProduct(productId: string): Promise<Product> {
    // Fetches product from the server.
    return {
    };
}