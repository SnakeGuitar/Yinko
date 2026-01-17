<script lang="ts">
    import { userService } from '$lib/services/userService';
    import type { CreateUserRequest } from '$lib/models/userTypes';

    let username = "";
    let email = "";
    let isLoading = false;
    let errorMessage = "";
    let successMessage = "";

    async function handleSubmit() {
        isLoading = true;
        errorMessage = "";
        successMessage = "";

        try {
            const request: CreateUserRequest = {
                identityId: "auth0|" + Date.now(),
                username,
                email,
                avatarUrl: "https://i.pravatar.cc/150"
            };

            const newId = await userService.signUp(request);
            
            successMessage = `¡Welcome! Your ID is: ${newId}`;
            username = "";
            email = "";

        } catch (error: any) {
            errorMessage = error.message || "An unexpected error occurred.";
        } finally {
            isLoading = false;
        }
    }
</script>

<form on:submit|preventDefault={handleSubmit} class="signup-card">
    <h2>Join Yinko</h2>

    <div class="form-group">
        <label for="username">User</label>
        <input id="username" type="text" bind:value={username} required disabled={isLoading} />
    </div>

    <div class="form-group">
        <label for="email">Email</label>
        <input id="email" type="email" bind:value={email} required disabled={isLoading} />
    </div>

    {#if errorMessage}
        <p class="error">❌ {errorMessage}</p>
    {/if}

    {#if successMessage}
        <p class="success">✅ {successMessage}</p>
    {/if}

    <button type="submit" disabled={isLoading}>
        {isLoading ? "Creating..." : "Register"}
    </button>
</form>

<style>
    .signup-card {
        background: white;
        padding: 2rem;
        border-radius: 12px;
        box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        max-width: 400px;
        margin: 0 auto;
    }
    .form-group { margin-bottom: 1rem; }
    input { width: 100%; padding: 0.5rem; margin-top: 0.25rem; }
    button { width: 100%; padding: 0.75rem; background: #646cff; color: white; border: none; border-radius: 4px; cursor: pointer; }
    button:disabled { background: #ccc; }
    .error { color: red; font-size: 0.9rem; }
    .success { color: green; font-weight: bold; }
</style>