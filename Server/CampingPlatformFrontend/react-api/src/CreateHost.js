import React from 'react';

function CreateHost() {
    return (
        <div class="container">
            <h1>Create</h1>
            <h4>Host</h4>
            <div class="row">
                <div class="col-md-4">
                    <form>
                        <div class="form-group">
                            <label>Date of birth</label>
                            <input class="form-control" type="date"/>
                        </div>
                        <div class="form-group">
                            <label>Telephone number</label>
                            <input class="form-control" />
                        </div>
                        <div class="form-group">
                            <label>Profile picture location</label>
                            <input class="form-control" />
                        </div>
                        <div class="form-group">
                            <input type="submit" value="Create" class="btn btn-primary" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default CreateHost;