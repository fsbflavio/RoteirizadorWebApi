import React from "react";
/*global google*/

class SearchBar extends React.Component {
    constructor(props) {
        super(props);
        this.autocompleteInput = React.createRef();
        this.autocomplete = null;
        this.handlePlaceChanged = this.handlePlaceChanged.bind(this);
    }

    componentDidMount() {

        const autocompleteT = new window.google.places.Autocomplete(this.autocompleteInput.current,
            { "types": ["geocode"] });

        this.autocomplete = autocompleteT;

        this.autocomplete.addListener('place_changed', this.handlePlaceChanged);
    }

    handlePlaceChanged() {
        const place = this.autocomplete.getPlace();
        this.props.onPlaceLoaded(place);
    }

    render() {
        return (
            <input
                ref={this.autocompleteInput}
                id="autocomplete"
                placeholder="Enter your address"
                required
                type="text"
            />
        );
    }
}

export default SearchBar;