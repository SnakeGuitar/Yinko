<script lang="ts">
    import SignUpForm from '$lib/components/SignUpForm.svelte';
</script>

<div class="page-container">
    <div class="intro">
        <h1>Begin your journey</h1>
        <p>Publish stories, earn Inkos and keep your streak.</p>
    </div>

    <SignUpForm />
</div>

<style>
    .page-container {
        display: grid;
        grid-template-columns: 1fr 1fr;
        height: 100vh;
        align-items: center;
        padding: 2rem;
        background-color: #f9f9f9;
    }
    .intro { padding-right: 2rem; }
</style>