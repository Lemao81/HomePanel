import React, { Component, ReactNode } from 'react';
import { Tile } from './Tile';
import { androidStartupTileConfiguration } from '../constants/TileData';

export class Panel extends Component {
  render(): ReactNode {
    return (
      <div className="panel">
        <Tile configuration={androidStartupTileConfiguration} />
      </div>
    );
  }
}
