import React from 'react';
import Tile from './Tile'

export class Panel extends React.Component {
    render() {
        return (
            <div className="panel">
                <Tile />
                <Tile />
            </div>
        )
    }
}

export default Panel