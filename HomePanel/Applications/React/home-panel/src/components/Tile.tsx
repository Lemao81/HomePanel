import React, { Component, ReactNode } from 'react';
import { ITileConfiguration } from '../models/ITileViewModel';

type TileState = {
  configuration: ITileConfiguration;
};

export class Tile extends Component<TileState> {
  state = {
    configuration: this.props.configuration
  };

  render(): ReactNode {
    return <div className="tile">{this.state.configuration.title}</div>;
  }
}
