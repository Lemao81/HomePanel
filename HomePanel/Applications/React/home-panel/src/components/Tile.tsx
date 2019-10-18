import React from 'react';
import { ITileViewModel } from '../models/ITileViewModel';

export class Tile extends React.Component {
  render() {
    const viewModel = this.props as ITileViewModel;

    return (
      <div className="tile">
        {viewModel.title}
      </div>
    )
  }
}