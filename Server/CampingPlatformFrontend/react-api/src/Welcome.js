import React from 'react';

function Welcome() {
    return (
        <div class="container align-middle">
            <main role="main" class="pb-3">
                <div class="text-center">
                    <h1 class="display-4">Welcome</h1>
                </div>
                <div class="fixed-middle">
                <div class="row mt-4">
                    <div class="col">
                        <div class="text-right">
                            <p class="lead">Already have an account?</p>
                            <a href="/login"><button type="button" class="btn btn-primary">Log in</button></a>
                        </div>
                    </div>
                    <div class="col">
                        <p class="lead">New here?</p>
                        <button type="button" class="btn btn-primary">Register as Host</button><br/>
                        <button type="button" class="btn btn-primary mt-2">Register as Guest</button>
                    </div>
                </div>
                </div>
            </main>
        </div>
    );
}

export default Welcome;