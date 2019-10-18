import React from 'react';
import { Tile } from './Tile'
import { androidDevStartup } from '../constants/TileData';

export class Panel extends React.Component {
    render() {
        return (
            <div className="panel">
                <Tile {...androidDevStartup} />
            </div>
        )
    }
}